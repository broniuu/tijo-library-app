using LibraryApp.Api.Db;
using LibraryApp.Api.Extensions;
using LibraryApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController
{
    private readonly LibraryDbContext _dbContext;

    public AuthorsController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorOfBookDto>> GetAll()
    {
        return await _dbContext.Authors.Select(x => x.ToAuthorOfBookDto()).ToListAsync();
    }
}