using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> option) : base(option)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BooksToAuthors> BooksToAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<BooksToAuthors>()
                .HasKey(x => new { x.BookId, x.AuthorId });


            modelBuilder.Entity<BooksToAuthors>()
                .HasOne(x => x.Author)
                .WithMany(z => z.BooksToAuthors)
                .HasForeignKey(y => y.AuthorId)
                .IsRequired();
            modelBuilder.Entity<BooksToAuthors>()
                .HasOne(x => x.Book)
                .WithMany(z => z.BooksToAuthors)
                .HasForeignKey(y => y.BookId)
                .IsRequired();



            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, Name = "Author1" }, new Author { Id = 2, Name = "Author2" }, new Author { Id = 3, Name = "Author3" });
            modelBuilder.Entity<Publisher>().HasData(new Publisher { Id = 1, Name = "Publisher1" }, new Author { Id = 2, Name = "Publisher2" }, new Author { Id = 3, Name = "Publisher3" });
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Book1", Description = "Test test", PublisherId = 1, Price = 17.15m, PublishedAt = DateTime.Now },
                new Book { Id = 2, Name = "Book2", Description = "Test test", PublisherId = 2, Price = 17.15m, PublishedAt = DateTime.Now },
                new Book { Id = 3, Name = "Book3", Description = "Test test", PublisherId = 3, Price = 17.15m, PublishedAt = DateTime.Now });
            modelBuilder.Entity<BooksToAuthors>().HasData(
                new BooksToAuthors {BookId = 1, AuthorId = 1 },
                new BooksToAuthors {BookId = 2, AuthorId = 2 },
                new BooksToAuthors {BookId = 3, AuthorId = 3 });


        }

    }
}
