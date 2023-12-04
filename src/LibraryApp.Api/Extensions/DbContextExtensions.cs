using LibraryApp.Api.Db;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Extensions;

public static class DbContextExtensions
{
    public static void AddLibraryDbContext(this IServiceCollection services, string databaseName)
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, databaseName);
        services.AddDbContext<LibraryDbContext>(options => 
            options.UseSqlite($"Data Source={dbPath}"));
    }
    
    public static async Task MigrateDb(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<LibraryDbContext>();
        if (dbContext == null)
        {
            throw new InvalidOperationException("Cannot find DB context.");
        }
        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Cannot migrate the database.", ex);
        }
    }
}