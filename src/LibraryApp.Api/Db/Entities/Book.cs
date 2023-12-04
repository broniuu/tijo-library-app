namespace LibraryApp.Api.Db.Entities;

public class Book
{
    public Guid BookId { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public List<Author> Authors { get; set; } = new();
    public List<Tag> Tags { get; set; } = new();
    public bool HasHardCover { get; set; }
    public int TotalCountOfPrintCopies { get; set; }
    public int CountOfBorrowedPrintCopies { get; set; }
    public string ImageUrl { get; set; }
}