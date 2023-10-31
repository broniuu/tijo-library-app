using LibraryApp.Api.Db;
using LibraryApp.Api.Extensions;
using LibraryApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("tags")]
public class TagsController
{
    private readonly LibraryDbContext _dbContext;

    public TagsController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<TagOfBookDto>> GetAll()
    {
        return await _dbContext.Tags.Select(x => x.ToTagOfBookDto()).ToListAsync();
    }
}