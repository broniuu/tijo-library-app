namespace LibraryApp.Api.Db.Entities;

public class Tag
{
    public Guid TagId { get; set; }
    public string Title { get; set; }
    public List<Book> Books { get; set; }
}