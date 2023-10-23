namespace LibraryApp.Shared.Dtos;

public class FilterBooksQuery
{
    public List<Guid>? TagIds { get; set; }
    public List<Guid>? AuthorIds { get; set; }
    public string? KeyWord { get; set; }
    public bool? HasHardCover { get; set; }
    public bool ShowBorrowed { get; set; }
}