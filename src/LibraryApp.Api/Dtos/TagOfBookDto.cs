using LibraryApp.Api.Db.Entities;

namespace LibraryApp.Api.Dtos;

public record TagOfBookDto(Guid TagId, string Title);