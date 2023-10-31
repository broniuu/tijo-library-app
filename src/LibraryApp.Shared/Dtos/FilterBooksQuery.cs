namespace LibraryApp.Shared.Dtos;

public class FilterBooksQuery
{
    public List<Guid>? TagIds { get; set; } = new();
    public List<Guid>? AuthorIds { get; set; } = new();
    public string? KeyWord { get; set; }
    public HardcoverRequirement HardcoverRequirement { get; set; }
    public bool ShowBorrowed { get; set; }
}

public enum HardcoverRequirement
{
    Has = 1,
    DontHave = 2,
    Indifferent = 3
}