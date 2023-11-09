using System.Collections;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using LibraryApp.Api.Db;
using LibraryApp.Api.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;
using Moq.EntityFrameworkCore;
using NSubstitute;

namespace LibraryApp.Api.UnitTests;

public static class DbMockFactory
{
    public static Mock<LibraryDbContext> Create(List<Book> books, List<Tag> tags, List<Author> authors)
    {
        var mockContext = new Mock<LibraryDbContext>();
        mockContext.Setup(m => m.Set<Book>()).ReturnsDbSet(books);
        mockContext.Setup(m => m.Set<Tag>()).ReturnsDbSet(tags);
        mockContext.Setup(m => m.Set<Author>()).ReturnsDbSet(authors);
        return mockContext;
    }
}