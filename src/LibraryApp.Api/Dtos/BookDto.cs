using LibraryApp.Api.Db.Entities;

namespace LibraryApp.Api.Dtos;

public record BookDto(
    Guid BookId, 
    string Title, 
    List<AuthorOfBookDto> Authors,
    List<TagOfBookDto> Tags,
    bool HasHardCover,
    int TotalCountOfPrintCopies,
    int CountOfBorrowedPrintCopies);