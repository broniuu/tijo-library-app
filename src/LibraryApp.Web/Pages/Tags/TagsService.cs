using System.Net.Http.Json;
using Blazored.Toast.Services;
using LibraryApp.Shared.Dtos;
using LibraryApp.Web.Pages.Books;

namespace LibraryApp.Web.Pages.Tags;

public class TagsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private readonly IToastService _toastService;
    private const string BaseUrl = "tags";

    public TagsService(HttpClient httpClient, ILogger<BooksService> logger, IToastService toastService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _toastService = toastService;
    }

    public async Task<List<SelectableTag>?> Get()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<SelectableTag>>(BaseUrl);
        }
        catch (Exception e)
        {
            _toastService.ShowError("Error occured while getting authors");
            _logger.LogError("{Message}", e.Message);
            return null;
        }
    }
}