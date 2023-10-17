using LibraryApp.Api.Db.Entities;
using LibraryApp.Api.Dtos;

namespace LibraryApp.Api.Extensions;

public static class BookExtensions
{
    private static BookDto ToBookDto(this Book book) => new(
        book.BookId, 
        book.Title, 
        book.Authors.Select(t => t.ToAuthorOfBookDto()).ToList(), 
        book.Tags.Select(t => t.ToTagOfBookDto()).ToList(), 
        book.HasHardCover, 
        //Todo: change when will be added to entity 
        true);
}