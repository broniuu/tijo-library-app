using LibraryApp.Api.Services;
using LibraryApp.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] FilterBooksQuery query)
    {
        return await _booksService.GetFilteredAsync(query);
    }
}