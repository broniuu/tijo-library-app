using FluentAssertions;
using LibraryApp.Api.Db;
using LibraryApp.Api.Db.Entities;
using LibraryApp.Api.Extensions;
using LibraryApp.Api.Services;
using LibraryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;

namespace LibraryApp.Api.UnitTests.Services;

public class GetFilteredAsyncTest : IAsyncLifetime
{
    private Mock<LibraryDbContext> _dbContextMock;
    private Mock<ILogger<BooksService>> _loggerMock;
    private static List<BookDto> _allBookDtos = Seed.Books.Select(x => x.ToBookDto()).ToList();

    public async Task InitializeAsync()
    {
        _dbContextMock = DbMockFactory.Create(Seed.Books, Seed.Tags, Seed.Authors);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    BooksService GetSut() => new(_dbContextMock.Object, _loggerMock.Object);

    [Theory]
    [MemberData(nameof(Get_WhenFilterQueryProvided_ThenReturnDataFilteredByQuery_TestData))]
    async Task WhenFilterQueryProvided_ThenReturnDataFilteredByQuery(FilterBooksQuery query, List<BookDto> expectedBookDtos)
    {
        //given
        _loggerMock = new Mock<ILogger<BooksService>>();
        var sut = GetSut();
        //when
        var result = await sut.GetFilteredAsync(query);
        //then
        result.Should().BeEquivalentTo(expectedBookDtos);
    }

    public static IEnumerable<object[]> Get_WhenFilterQueryProvided_ThenReturnDataFilteredByQuery_TestData()
    {
        return FilterQueryDataGenerator.GetData(_allBookDtos);
    }
}