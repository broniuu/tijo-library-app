using LibraryApp.Api.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Db;

public class LibraryDbContext : DbContext
{
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) {}
}