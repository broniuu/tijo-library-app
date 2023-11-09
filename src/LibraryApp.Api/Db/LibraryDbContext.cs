using LibraryApp.Api.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Api.Db;

public class LibraryDbContext : DbContext
{
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    
    public string DbPath { get; }

    public LibraryDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "library.db");
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}