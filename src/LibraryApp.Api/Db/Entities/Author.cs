namespace LibraryApp.Api.Db.Entities;

public class Author
{
    public Guid AuthorId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Book> Books { get; set; }
}