using Athenaeum.Models;
using Athenaeum.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace Athenaeum.Data
{
    public class AthenaeumContext : DbContext
    {
        public AthenaeumContext(DbContextOptions<AthenaeumContext> options) :base (options)
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BookInCollection> BookInCollection { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBook> UserBook { get; set; }
        public DbSet<UserCollection> UserCollection { get; set; }

        public DbSet<view_BookInCollection_UserBook> view_BookInCollection_UserBook { get; set; }
        public DbSet<view_BookInCollection_Publisher> view_BookInCollection_Publisher { get; set; }
    }
}
