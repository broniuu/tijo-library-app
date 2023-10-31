using System.Net.Http.Json;
using Blazored.Toast.Services;
using LibraryApp.Web.Pages.Books;

namespace LibraryApp.Web.Pages.Authors;

public class AuthorsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private readonly IToastService _toastService;
    private const string BaseUrl = "authors";

    public AuthorsService(HttpClient httpClient, ILogger<BooksService> logger, IToastService toastService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _toastService = toastService;
    }

    public async Task<List<SelectableAuthor>?> Get()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<SelectableAuthor>>(BaseUrl);
        }
        catch (Exception e)
        {
            _toastService.ShowError("Error occured while getting authors");
            _logger.LogError("{Message}", e.Message);
            return null;
        }
    }
}