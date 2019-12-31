using HomeLi.Entities.Models;

using Microsoft.EntityFrameworkCore;

namespace HomeLi.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Series> Series { get; set; }
    }
}