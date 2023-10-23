using System.Collections;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace LibraryApp.Web.Shared;

public static class QueryStringBuilder
{
    public static string CreateQueryString(string baseUrl, object baseObject)
    {
        var keyValuePairs = baseObject.GetType()
            .GetProperties()
            .ToDictionary(p => p.Name, p => ToString(p.GetValue(baseObject)));
        foreach (var keyValuePair in keyValuePairs.Where(keyValuePair => keyValuePair.Value == StringValues.Empty))
        {
            keyValuePairs.Remove(keyValuePair.Key);
        }
        return baseUrl + QueryString.Create(keyValuePairs).Value;
    }

    private static StringValues ToString(object? value)
    {
        return value switch
        {
            null => StringValues.Empty,
            DateTimeOffset date => date.ToString("o", CultureInfo.InvariantCulture),
            IEnumerable collection => new StringValues(collection.Cast<object>()
                .Where(x => x != null)
                .Select(x => x.ToString())
                .ToArray()),
            _ => value.ToString()
        };
    }
}