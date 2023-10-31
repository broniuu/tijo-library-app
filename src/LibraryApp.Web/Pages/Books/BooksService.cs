using System.Net.Http.Json;
using Blazored.Toast.Services;
using LibraryApp.Shared.Dtos;
using LibraryApp.Web.Shared;

namespace LibraryApp.Web.Pages.Books;

public class BooksService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private readonly IToastService _toastService;
    private const string BaseUrl = "books";

    public BooksService(HttpClient httpClient, ILogger<BooksService> logger, IToastService toastService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _toastService = toastService;
    }

    public async Task<List<BookDto>?>GetFiltered(FilterBooksQuery query)
    {
        var queryString = QueryStringBuilder.CreateQueryString(BaseUrl, query);
        try
        {
            return await _httpClient.GetFromJsonAsync<List<BookDto>>(queryString);
        }
        catch (Exception e)
        {
            _toastService.ShowError("Error occured while getting books");
            _logger.LogError("{Message}", e.Message);
            return null;
        }
        
    }
}