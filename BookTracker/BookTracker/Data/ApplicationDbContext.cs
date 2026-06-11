using BookTracker.Model;
using BookTracker.Model.AuthApp;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
