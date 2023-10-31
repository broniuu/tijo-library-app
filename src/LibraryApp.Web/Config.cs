using LibraryApp.Web.Pages.Authors;
using LibraryApp.Web.Pages.Books;
using LibraryApp.Web.Pages.Tags;

namespace LibraryApp.Web;

public static class Config
{
    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        const string apiAddress = "http://localhost:5022/";
        return services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services.AddScoped<AuthorsService>()
            .AddScoped<TagsService>()
            .AddScoped<BooksService>();
    }
}