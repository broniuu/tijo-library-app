using LibraryApp.Api.Db.Entities;

namespace LibraryApp.Api.Db;

public static class Seed
{
    private static Tag _thrillerTag = new() { Title = "thriller" };
    private static Tag _fantasyTag = new() { Title = "fantasy" };
    private static Tag _scienceFictionTag = new() { Title = "science fiction" };
    private static Tag _historyTag = new() { Title = "history" };
    private static Tag _womanTag = new() { Title = "woman" };
    private static Tag _sportTag = new() { Title = "sport" };
    private static Tag _kitchenTag = new() { Title = "kitchen" };
    private static Tag _theologyTag = new() { Title = "theology" };

    private static Author _lewandowskiAuthor = new() { Name = "Robert", Surname = "Lewandowski" };
    private static Author _sapkowskiAuthor = new() { Name = "Andrzej", Surname = "Sapkowski" };
    private static Author _tolkienAuthor = new() { Name = "John Ronald Reuel", Surname = "Tolkien" };
    private static Author _rowlingAuthor = new() { Name = "Joanne", Surname = "Rowling" };
    private static Author _aquinasAuthor = new() { Name = "Thomas", Surname = "Aquinas" };
    private static Author _lefebvreAuthor = new() { Name = "Marcel", Surname = "Lefebvre" };
    private static Author _mrozAuthor = new() { Name = "Remigiusz", Surname = "Mróz" };
    private static Author _maklowiczAuthor = new() { Name = "Robert", Surname = "Makłowicz" };

    private static readonly List<Tag> Tags = new()
    {
        _thrillerTag,
        _fantasyTag,
        _scienceFictionTag,
        _historyTag,
        _womanTag,
        _sportTag,
        _kitchenTag,
        _theologyTag
    };

    private static readonly List<Author> Authors = new()
    {
        _lewandowskiAuthor,
        _sapkowskiAuthor,
        _tolkienAuthor,
        _rowlingAuthor,
        _aquinasAuthor,
        _lefebvreAuthor,
        _mrozAuthor,
        _maklowiczAuthor,
    };

    private static readonly List<Book> Books = new()
    {
        new Book
        {
            Title = "Summa Contra Brzęczek",
            Authors = new List<Author> { _aquinasAuthor, _lewandowskiAuthor },
            Tags = new List<Tag> { _theologyTag, _historyTag, _sportTag },
            HasHardCover = true
        },
        new Book
        {
            Title = "An Good Dish For Hogwart Catholics",
            Authors = new List<Author> { _lefebvreAuthor, _rowlingAuthor, _maklowiczAuthor },
            Tags = new List<Tag> { _kitchenTag, _fantasyTag, _theologyTag },
            HasHardCover = true
        },
        new Book
        {
            Title = "Final Appeal",
            Authors = new List<Author> { _mrozAuthor },
            Tags = new List<Tag> { _thrillerTag, _womanTag },
            HasHardCover = false
        },
        new Book
        {
            Title = "Revision",
            Authors = new List<Author> { _mrozAuthor },
            Tags = new List<Tag> { _thrillerTag },
            HasHardCover = false
        },
        new Book
        {
            Title = "Tragedy of Second Vatican Council",
            Authors = new List<Author> { _lefebvreAuthor, _aquinasAuthor },
            Tags = new List<Tag> { _thrillerTag, _historyTag, _theologyTag },
            HasHardCover = false
        },
        new Book
        {
            Title = "Lord of the Dumbledore",
            Authors = new List<Author> { _rowlingAuthor, _tolkienAuthor },
            Tags = new List<Tag> { _thrillerTag, _fantasyTag },
            HasHardCover = true
        },
        new Book
        {
            Title = "They Have Uncrowned Him",
            Authors = new List<Author> { _lefebvreAuthor },
            Tags = new List<Tag> { _thrillerTag, _fantasyTag, _thrillerTag },
            HasHardCover = true
        },
        new Book
        {
            Title = "How to not play",
            Authors = new List<Author> { _lewandowskiAuthor },
            Tags = new List<Tag> { _sportTag },
            HasHardCover = true
        },
        new Book
        {
            Title = "Witcher can into space",
            Authors = new List<Author> { _sapkowskiAuthor },
            Tags = new List<Tag> { _scienceFictionTag, _thrillerTag },
            HasHardCover = true
        }
    };

    public static async Task FillInDbAsync(ILogger logger)
    {
        await using var dbContext = new LibraryDbContext();
        if (!dbContext.Tags.Any())
        {
            await dbContext.Tags.AddRangeAsync(Tags);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Tags added");
        }

        if (!dbContext.Authors.Any())
        {
            await dbContext.Authors.AddRangeAsync(Authors);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Authors added");
        }

        if (!dbContext.Books.Any())
        {
            await dbContext.Books.AddRangeAsync(Books);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Books added");
        }
    }
}