using FluentAssertions;
using LibraryApp.Api.Db;
using LibraryApp.Api.Db.Entities;
using LibraryApp.Api.Extensions;
using LibraryApp.Api.Services;
using LibraryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.GC;

namespace LibraryApp.Api.UnitTests.IntegrationTests.Services;

public class BookServiceTests : IClassFixture<ServiceFixture>
{
    public BookServiceTests(ServiceFixture serviceFixture)
    {
        _serviceProvider = serviceFixture.ServiceProvider;
    }
    
    private readonly IServiceProvider _serviceProvider;
    private static List<BookDto> _allBookDtos = Seed.Books.Select(x => x.ToBookDto()).ToList();

    private BooksService GetSut() => _serviceProvider.GetRequiredService<BooksService>();

    [Theory]
    [MemberData(nameof(Get_WhenProvideQuery_ThenReturnBooks_TestData))]
    public async Task WhenProvideQuery_ThenReturnBooks(FilterBooksQuery query, List<BookDto> expectedBookDtos)
    {
        //Given
        var sut = GetSut();
        //When
        var result = await sut.GetFilteredAsync(query);
        //Then
        result.Should().BeEquivalentTo(expectedBookDtos);

    }

    public static IEnumerable<object[]> Get_WhenProvideQuery_ThenReturnBooks_TestData()
    {
        return FilterQueryDataGenerator.GetData(_allBookDtos);
    }
}