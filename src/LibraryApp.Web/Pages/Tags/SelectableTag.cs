using LibraryApp.Shared.Dtos;
using LibraryApp.Web.Shared;

namespace LibraryApp.Web.Pages.Tags;

public record SelectableTag(Guid TagId, string Title) : TagOfBookDto(TagId, Title), ISelectable
{
    public bool IsSelected { get; set; }
}