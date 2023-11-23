using LibraryApp.Api.Db;
using LibraryApp.Api.Db.Entities;
using LibraryApp.Api.Extensions;
using LibraryApp.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Api.UnitTests.IntegrationTests;

public class ServiceFixture : IAsyncLifetime
{
    public IServiceProvider ServiceProvider { get; private set; } = null!;
    private const string TestDbName = "libraryTest.db";
    
    public async Task InitializeAsync()
    {
        var services = new ServiceCollection();
        services.AddLibraryDbContext(TestDbName);
        services.AddTransient<BooksService>();
        services.AddLogging();
        ServiceProvider = services.BuildServiceProvider();
        await using var scope = ServiceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        await dbContext.Database.MigrateAsync();
        await dbContext.Set<Tag>().AddRangeAsync(Seed.Tags);
        await dbContext.SaveChangesAsync();
        await dbContext.Set<Author>().AddRangeAsync(Seed.Authors);
        await dbContext.SaveChangesAsync();
        await dbContext.Set<Book>().AddRangeAsync(Seed.Books);
        await dbContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await using var scope = ServiceProvider.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        var deleted = await dbContext.Database.EnsureDeletedAsync();
        Console.WriteLine(deleted ? "Baza danych została usunięta." : "Baza danych nie istniała.");
    }
}