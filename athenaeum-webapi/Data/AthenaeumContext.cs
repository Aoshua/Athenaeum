﻿using Microsoft.EntityFrameworkCore;

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
            //modelBuilder.Entity<User>()
            //    .HasMany(p => p.Collections)
            //    .WithOne();

            //modelBuilder.Entity<UserCollection>()
            //    .HasOne(p => p.Collection);

            //modelBuilder.Entity<UserCollection>()
            //    .HasOne(p => p.User);

            modelBuilder.Entity<UserCollection>()
                .HasKey(k => new { k.UserId, k.CollectionId });

            modelBuilder.Entity<UserCollection>()
                .HasOne<User>(u => u.User)
                .WithMany(uc => uc.UserCollections)
                .HasForeignKey(k => k.UserId);

            modelBuilder.Entity<UserCollection>()
                .HasOne<Collection>(c => c.Collection)
                .WithMany(uc => uc.UserCollections)
                .HasForeignKey(k => k.CollectionId);
        }
    }
}
