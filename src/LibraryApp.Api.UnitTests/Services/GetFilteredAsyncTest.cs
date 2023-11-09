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
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new() { Seed.MaklowiczAuthor.AuthorId, Seed.AquinasAuthor.AuthorId },
                TagIds = null,
                HardcoverRequirement = HardcoverRequirement.Indifferent,
                ShowBorrowed = true,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes(0, 1, 4)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new(),
                TagIds = null,
                HardcoverRequirement = HardcoverRequirement.Indifferent,
                ShowBorrowed = true,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes(0, 1, 2, 3, 4, 5, 6, 7, 8)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new() {},
                TagIds = new List<Guid>() { Seed.HistoryTag.TagId, Seed.KitchenTag.TagId, Seed.ThrillerTag.TagId},
                HardcoverRequirement = HardcoverRequirement.Indifferent,
                ShowBorrowed = true,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes(0, 1, 2, 3, 4, 5, 6, 8)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new(),
                TagIds = new(),
                HardcoverRequirement = HardcoverRequirement.DontHave,
                ShowBorrowed = true,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes(2, 3, 4)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new(),
                TagIds = new(),
                HardcoverRequirement = HardcoverRequirement.Indifferent,
                ShowBorrowed = false,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes(1, 3, 4, 5, 6, 7, 8)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new(),
                TagIds = new(),
                HardcoverRequirement = HardcoverRequirement.Indifferent,
                ShowBorrowed = true,
                KeyWord = "of"
            },
            GetBookDtosByIndexes(4, 5)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new(),
                TagIds = new(),
                HardcoverRequirement = HardcoverRequirement.Has,
                ShowBorrowed = false,
                KeyWord = "a"
            },
            GetBookDtosByIndexes(1, 6, 7, 8)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new() {Seed.SapkowskiAuthor.AuthorId},
                TagIds = new(),
                HardcoverRequirement = HardcoverRequirement.Has,
                ShowBorrowed = false,
                KeyWord = "a"
            },
            GetBookDtosByIndexes(8)
        };
        yield return new object[]
        {
            new FilterBooksQuery
            {
                AuthorIds = new() {Seed.LefebvreAuthor.AuthorId},
                TagIds = new() {Seed.KitchenTag.TagId},
                HardcoverRequirement = HardcoverRequirement.DontHave,
                ShowBorrowed = true,
                KeyWord = string.Empty
            },
            GetBookDtosByIndexes()
        };
    }

    private static List<BookDto> GetBookDtosByIndexes(params int[] indexes) =>
        indexes.Select(i => _allBookDtos[i]).ToList();
}