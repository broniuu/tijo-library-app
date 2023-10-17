namespace LibraryApp.Api.Db.Entities;

public class Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public List<Author> Authors { get; set; }
    public List<Tag> Tags { get; set; } = new();
    public bool HasHardCover { get; set; }
    public int TotalCountOfPrintCopies { get; set; }
    public int CountOfBorrowedPrintCopies { get; set; }
}