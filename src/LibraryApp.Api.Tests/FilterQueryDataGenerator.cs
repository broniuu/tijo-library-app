using LibraryApp.Api.Db;
using LibraryApp.Shared.Dtos;

namespace LibraryApp.Api.UnitTests;

public class FilterQueryDataGenerator
{
    public static IEnumerable<object[]> GetData(List<BookDto> allBookDtos)
    {
        // yield return new object[]
        // {
        //     new FilterBooksQuery
        //     {
        //         AuthorIds = new() { Seed.MaklowiczAuthor.AuthorId, Seed.AquinasAuthor.AuthorId },
        //         TagIds = null,
        //         HardcoverRequirement = HardcoverRequirement.Indifferent,
        //         ShowBorrowed = true,
        //         KeyWord = string.Empty
        //     },
        //     GetBookDtosByIndexes(allBookDtos,0, 1, 4)
        // };
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
            GetBookDtosByIndexes(allBookDtos,0, 1, 2, 3, 4, 5, 6, 7, 8)
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
            GetBookDtosByIndexes(allBookDtos,0, 1, 2, 3, 4, 5, 6, 8)
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
            GetBookDtosByIndexes(allBookDtos,2, 3, 4)
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
            GetBookDtosByIndexes(allBookDtos,1, 3, 4, 5, 6, 7, 8)
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
            GetBookDtosByIndexes(allBookDtos,4, 5)
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
            GetBookDtosByIndexes(allBookDtos,1, 6, 7, 8)
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
            GetBookDtosByIndexes(allBookDtos,8)
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
            GetBookDtosByIndexes(allBookDtos)
        };
    }
    
    private static List<BookDto> GetBookDtosByIndexes(IReadOnlyList<BookDto> allBookDtos, params int[] indexes) =>
        indexes.Select(i => allBookDtos[i]).ToList();
}