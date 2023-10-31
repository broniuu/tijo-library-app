namespace LibraryApp.Shared.Dtos;

public record BookDto(
    Guid BookId, 
    string Title, 
    List<AuthorOfBookDto> Authors,
    List<TagOfBookDto> Tags,
    bool HasHardCover,
    int TotalCountOfPrintCopies,
    int CountOfBorrowedPrintCopies,
    string ImageUrl);