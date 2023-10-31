using LibraryApp.Api.Db.Entities;
using LibraryApp.Shared.Dtos;

namespace LibraryApp.Api.Extensions;

public static class AuthorExtensions
{
    public static AuthorOfBookDto ToAuthorOfBookDto(this Author author) => new(author.AuthorId, author.Name, author.Surname);
}