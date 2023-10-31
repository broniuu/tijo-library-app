using LibraryApp.Shared.Dtos;
using LibraryApp.Web.Shared;

namespace LibraryApp.Web.Pages.Authors;

public record SelectableAuthor(Guid AuthorId, string Name, string Surname) : AuthorOfBookDto(AuthorId, Name, Surname), ISelectable
{
    public bool IsSelected { get; set; } 
}