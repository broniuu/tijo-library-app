﻿using System.Linq.Expressions;

namespace LibraryApp.Api.Extensions;

public static class ExpressionExtensions
{
    public static Expression Simplify(this Expression expression)
    {
        var searcher = new ParameterlessExpressionSearcher();
        searcher.Visit(expression);
        return new ParameterlessExpressionEvaluator(searcher.ParameterlessExpressions).Visit(expression);
    }

    public static Expression<T> Simplify<T>(this Expression<T> expression)
    {
        return (Expression<T>)Simplify((Expression)expression);
    }

    private class ParameterlessExpressionEvaluator : ExpressionVisitor
    {
        private HashSet<Expression> parameterlessExpressions;

        public ParameterlessExpressionEvaluator(HashSet<Expression> parameterlessExpressions)
        {
            this.parameterlessExpressions = parameterlessExpressions;
        }

        public override Expression Visit(Expression node)
        {
            if (parameterlessExpressions.Contains(node))
                return Evaluate(node);
            else
                return base.Visit(node);
        }

        private Expression Evaluate(Expression node)
        {
            if (node.NodeType == ExpressionType.Constant)
            {
                return node;
            }

            object value = Expression.Lambda(node).Compile().DynamicInvoke();
            return Expression.Constant(value, node.Type);
        }
    }

    private class ParameterlessExpressionSearcher : ExpressionVisitor
    {
        public HashSet<Expression> ParameterlessExpressions { get; } = new HashSet<Expression>();
        private bool containsParameter = false;

        public override Expression Visit(Expression node)
        {
            bool originalContainsParameter = containsParameter;
            containsParameter = false;
            base.Visit(node);
            if (!containsParameter)
            {
                if (node?.NodeType == ExpressionType.Parameter)
                    containsParameter = true;
                else
                    ParameterlessExpressions.Add(node);
            }

            containsParameter |= originalContainsParameter;

            return node;
        }
    }
}