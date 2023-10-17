using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private ILogger<BooksController> _logger;
}