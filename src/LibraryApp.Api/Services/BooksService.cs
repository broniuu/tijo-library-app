using LibraryApp.Api.Db;
using LibraryApp.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Services;

public class BooksService
{
    private LibraryDbContext _dbContext;


    public BooksService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<BookDto>> GetFiltered()
    {
        throw new NotImplementedException();
    }
}