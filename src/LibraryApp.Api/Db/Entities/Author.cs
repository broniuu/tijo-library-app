namespace LibraryApp.Api.Db.Entities;

public class Author
{
    public Guid AuthorId { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Book> Books { get; set; }
}