using LibraryApp.Api.Db.Entities;
using LibraryApp.Shared.Dtos;

namespace LibraryApp.Api.Extensions;

public static class BookExtensions
{
    public static BookDto ToBookDto(this Book book) => new(
        book.BookId, 
        book.Title, 
        book.Authors.Select(t => t.ToAuthorOfBookDto()).ToList(), 
        book.Tags.Select(t => t.ToTagOfBookDto()).ToList(), 
        book.HasHardCover, 
        book.TotalCountOfPrintCopies,
        book.CountOfBorrowedPrintCopies,
        book.ImageUrl);
}