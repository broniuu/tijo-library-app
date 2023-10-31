namespace LibraryApp.Shared.Dtos;

public record AuthorOfBookDto(Guid AuthorId, string Name, string Surname)
{
    public string GetNameAndSurname => $"{Name} {Surname}";
}