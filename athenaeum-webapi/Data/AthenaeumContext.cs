using Microsoft.EntityFrameworkCore;

namespace athenaeum_webapi.Data
{
    public class AthenaeumContext : DbContext
    {
        public AthenaeumContext(DbContextOptions<AthenaeumContext> options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserBooks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(x => x.UserCollections)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserBook>()
                .HasOne(x => x.Book)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.UserBookId);

            modelBuilder.Entity<UserCollection>()
                .HasOne(x => x.Collection)
                .WithMany(x => x.UserCollections)
                .HasForeignKey(x => x.UserCollectionId);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.BooksInCollection)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);
        }
    }
}
