using LibraryApp.Api.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Db;

public static class Seed
{
    
    public static Tag ThrillerTag = new() { Title = "thriller" };
    public static Tag FantasyTag = new() { Title = "fantasy" };
    public static Tag ScienceFictionTag = new() { Title = "science fiction" };
    public static Tag HistoryTag = new() { Title = "history" };
    public static Tag WomanTag = new() { Title = "woman" };
    public static Tag SportTag = new() { Title = "sport" };
    public static Tag KitchenTag = new() { Title = "kitchen" };
    public static Tag TheologyTag = new() { Title = "theology" };

    public static Author LewandowskiAuthor = new() { Name = "Robert", Surname = "Lewandowski" };
    public static Author SapkowskiAuthor = new() { Name = "Andrzej", Surname = "Sapkowski" };
    public static Author TolkienAuthor = new() { Name = "John Ronald Reuel", Surname = "Tolkien" };
    public static Author RowlingAuthor = new() { Name = "Joanne", Surname = "Rowling" };
    public static Author AquinasAuthor = new() { Name = "Thomas", Surname = "Aquinas" };
    public static Author LefebvreAuthor = new() { Name = "Marcel", Surname = "Lefebvre" };
    public static Author MrozAuthor = new() { Name = "Remigiusz", Surname = "Mróz" };
    public static Author MaklowiczAuthor = new() { Name = "Robert", Surname = "Makłowicz" };

    public static readonly List<Tag> Tags = new()
    {
        ThrillerTag,
        FantasyTag,
        ScienceFictionTag,
        HistoryTag,
        WomanTag,
        SportTag,
        KitchenTag,
        TheologyTag
    };

    public static readonly List<Author> Authors = new()
    {
        LewandowskiAuthor,
        SapkowskiAuthor,
        TolkienAuthor,
        RowlingAuthor,
        AquinasAuthor,
        LefebvreAuthor,
        MrozAuthor,
        MaklowiczAuthor,
    };

    public static readonly List<Book> Books = new()
    {
        new Book
        {
            Title = "Summa Contra Brzęczek",
            Authors = new List<Author> { AquinasAuthor, LewandowskiAuthor },
            Tags = new List<Tag> { TheologyTag, HistoryTag, SportTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 14,
            CountOfBorrowedPrintCopies = 14,
            ImageUrl = "data:image/jpeg;base64,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"
        },
        new Book
        {
            Title = "An Good Dish For Hogwart Catholics",
            Authors = new List<Author> { LefebvreAuthor, RowlingAuthor, MaklowiczAuthor },
            Tags = new List<Tag> { KitchenTag, FantasyTag, TheologyTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 11,
            CountOfBorrowedPrintCopies = 4,
            ImageUrl = "https://ecsmedia.pl/c/c-k-kuchnia-b-iext131156627.jpg"
        },
        new Book
        {
            Title = "Final Appeal",
            Authors = new List<Author> { MrozAuthor },
            Tags = new List<Tag> { ThrillerTag, WomanTag },
            HasHardCover = false,
            TotalCountOfPrintCopies = 20,
            CountOfBorrowedPrintCopies = 20,
            ImageUrl = "https://target.scene7.com/is/image/Target/GUEST_9ce9c49a-a569-498d-878d-cee2cc5550a1?wid=488&hei=488&fmt=pjpeg"
        },
        new Book
        {
            Title = "Revision",
            Authors = new List<Author> { MrozAuthor },
            Tags = new List<Tag> { ThrillerTag },
            HasHardCover = false,
            TotalCountOfPrintCopies = 11,
            CountOfBorrowedPrintCopies = 10,
            ImageUrl = "https://webimage.pl/pics/498/0/b9788366570498.jpg"
        },
        new Book
        {
            Title = "Tragedy of Second Vatican Council",
            Authors = new List<Author> { LefebvreAuthor, AquinasAuthor },
            Tags = new List<Tag> { ThrillerTag, HistoryTag, TheologyTag },
            HasHardCover = false,
            TotalCountOfPrintCopies = 18,
            CountOfBorrowedPrintCopies = 7,
            ImageUrl = "https://static.wikia.nocookie.net/starwars/images/c/c0/A_Tale_of_Tragedy_SWDConv.png"
            
        },
        new Book
        {
            Title = "Lord of the Dumbledore",
            Authors = new List<Author> { RowlingAuthor, TolkienAuthor },
            Tags = new List<Tag> { ThrillerTag, FantasyTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 10,
            CountOfBorrowedPrintCopies = 9,
            ImageUrl = "data:image/jpeg;base64,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"
        },
        new Book
        {
            Title = "They Have Uncrowned Him",
            Authors = new List<Author> { LefebvreAuthor },
            Tags = new List<Tag> { ThrillerTag, FantasyTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 37,
            CountOfBorrowedPrintCopies = 21,
            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1186678544i/1674973.jpg"
        },
        new Book
        {
            Title = "How to not play",
            Authors = new List<Author> { LewandowskiAuthor },
            Tags = new List<Tag> { SportTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 36,
            CountOfBorrowedPrintCopies = 24,
            ImageUrl = "https://ocdn.eu/sport-images-transforms/1/QT5k9lBaHR0cHM6Ly9vY2RuLmV1L3B1bHNjbXMvTURBXy8zOTFjMWU4YmQ3NGVjMjBhOGQzMTc5ZWYwNTUzY2E0NS5qcGeTlQMAzH3ND7nNCNiVAs0EsADCw5MJpmNiZWE2MgbeAAKhMAGhMQE/robert-lewandowski.jpg"
        },
        new Book
        {
            Title = "Witcher can into space",
            Authors = new List<Author> { SapkowskiAuthor },
            Tags = new List<Tag> { ScienceFictionTag, ThrillerTag },
            HasHardCover = true,
            TotalCountOfPrintCopies = 20,
            CountOfBorrowedPrintCopies = 5,
            ImageUrl = "https://cdn.kobo.com/book-images/edfcf36b-b4ed-4819-a88f-25af814815e8/353/569/90/False/the-saga-of-the-witcher.jpg"
        }
    };

    public static async Task FillInDbAsync(this IApplicationBuilder app)
    {
        await using var scope = app.ApplicationServices.CreateAsyncScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<LibraryDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();
        if (!dbContext.Set<Tag>().Any())
        {
            await dbContext.Set<Tag>().AddRangeAsync(Tags);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Tags added");
        }

        if (!dbContext.Set<Author>().Any())
        {
            await dbContext.Set<Author>().AddRangeAsync(Authors);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Authors added");
        }

        if (!dbContext.Set<Book>().Any())
        {
            await dbContext.Set<Book>().AddRangeAsync(Books);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Books added");
        }
    }
}