using LibraryApp.Api.Builders;
using LibraryApp.Api.Db;
using LibraryApp.Api.Db.Entities;
using LibraryApp.Api.Extensions;
using LibraryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Services;

public class BooksService
{
    private readonly LibraryDbContext _dbContext;
    private readonly ILogger<BooksService> _logger;

    public BooksService(LibraryDbContext dbContext, ILogger<BooksService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<BookDto>> GetFilteredAsync(FilterBooksQuery query)
    {
        var predicate = PredicateBuilder.True<Book>();

        if (query.AuthorIds is { Count: > 0 })
        {
            var authorsFilter = PredicateBuilder.False<Book>();
            predicate = query.AuthorIds?.Aggregate(authorsFilter, (current, authorId) => current
                .Or(b => b.Authors.Any(a => a.AuthorId == authorId))) ?? predicate;
        }

        if (query.TagIds is { Count: > 0 })
        {
            var tagsFilter = PredicateBuilder.False<Book>();
            predicate = predicate.And(query.TagIds.Aggregate(tagsFilter,
                (current, tagId) => current.Or(b => b.Tags.Any(t => t.TagId == tagId))));
        }

        if (query.KeyWord is not null && query.KeyWord != string.Empty)
        {
            predicate = predicate.And(b => b.Title.ToLower().Contains(query.KeyWord.ToLower()));
        }

        predicate = query.HardcoverRequirement switch
        {
            HardcoverRequirement.Has => predicate.And(b => b.HasHardCover),
            HardcoverRequirement.DontHave => predicate.And(b => !b.HasHardCover),
            _ => predicate
        };
        if (!query.ShowBorrowed)
        {
            predicate = predicate.And(b => b.CountOfBorrowedPrintCopies < b.TotalCountOfPrintCopies);
        }

        _logger.LogInformation("Filter query: {Predicate}", predicate.ToString());
        var books = await _dbContext.Set<Book>()
            .Where(predicate)
            .Include(b => b.Authors)
            .Include(b => b.Tags)
            .Select(b => b.ToBookDto())
            .ToListAsync();
        return books;
    }
}