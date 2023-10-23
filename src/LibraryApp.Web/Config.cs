using LibraryApp.Web.Pages.Books;

namespace LibraryApp.Web;

public static class Config
{
    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        const string apiAddress = "http://localhost:5022/";
        return services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });
    }
}