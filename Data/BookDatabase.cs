using BooksWeb.Models;
using Microsoft.EntityFrameworkCore;

public class BookDatabase: DbContext{

     public BookDatabase(DbContextOptions options) : base(options) {}

     // we override the OnModelCreating method here.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookReader>().HasKey(br => new {br.BookId, br.ReaderId});
    }

    public DbSet<Book> Books { get; set; }   
    public DbSet<Reader> Readers { get; set; }
    public DbSet<BookReader> BooksReaders { get; set; }
}