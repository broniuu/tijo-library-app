using LibraryApp.Shared.Dtos;

namespace LibraryApp.Shared;

public static class BookDtoExtensions
{
    public static bool CanBeBorrowed(this BookDto bookDto) =>
        bookDto.CountOfBorrowedPrintCopies < bookDto.TotalCountOfPrintCopies;
}