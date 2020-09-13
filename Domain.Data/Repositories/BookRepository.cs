using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data.Helpers;
using Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(string connectionString, IRepositoryContextFactory contextFactory)
           : base(connectionString, contextFactory)
        { }

        public async Task<Page<Book>> GetBooks(int index, int pageSize, string searchPropertyName, string searchTerm)
        {
            var result = new Page<Book>() { CurrentPage = index, PageSize = pageSize, SearchPropertyName = searchPropertyName, SearchTerm = searchTerm };

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var Authors = context.Authors.ToList();
                var query = context.Books
                    .Include(c => c.Publisher)
                    .Include(c => c.BooksToAuthors).ThenInclude(cs => cs.Author).AsQueryable();
                if (!string.IsNullOrEmpty(searchPropertyName) &&
                    !string.IsNullOrEmpty(searchTerm))
                {
                    if(searchPropertyName.Contains("Book"))
                    {
                        result.Records = await query.Where(c =>searchTerm.Contains(c.Name)).ToListAsync();
                        
                    }
                    if(searchPropertyName.Contains("Author"))
                    {
                        result.Records = await query.Where(c => c.BooksToAuthors.Any(x=>searchTerm.Contains(x.Author.Name))).ToListAsync();
                    }
                    if(searchPropertyName.Contains("Publisher"))
                    {
                        result.Records = await query.Where(c => searchTerm.Contains(c.Publisher.Name)).ToListAsync();
                    }
                    return result;
                }

                result.TotalPages = await query.CountAsync();
                result.Records = await query.OrderBy(c => c.Name).Skip(index * pageSize).Take(pageSize).OrderByDescending(c => c.Id).ToListAsync();
            }
            return result;
        }
        public async Task AddBook(Book newBook)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var dbr = context.Books.Where(c => c.Name == newBook.Name).Count();
                if(dbr==0)
                {
                    newBook.PublishedAt = DateTime.Now;
                    context.Books.Add(newBook);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<ServiceResponse<Book>> AddBookToAuthor(BooksToAuthors newBookToAuthor)
        {
            ServiceResponse<Book> response = new ServiceResponse<Book>();
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                try
                {
                    Book book = await context.Books
                    .Include(c => c.Publisher)
                    .Include(c => c.BooksToAuthors).ThenInclude(cs => cs.Author)
                    .FirstOrDefaultAsync(c => c.Id == newBookToAuthor.BookId);
                    if (book == null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "Book not found.";
                        return response;
                    }
                    Author author = await context.Authors
                        .FirstOrDefaultAsync(s => s.Id == newBookToAuthor.AuthorId);

                    if (author == null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "Book not found.";
                        return response;
                    }

                    BooksToAuthors booksToAuthors = new BooksToAuthors
                    {
                        Book = book,
                        Author = author
                    };

                    await context.AddAsync(booksToAuthors);
                    await context.SaveChangesAsync();
                    response.Success = true;
                    response.Data = book;
                }
                catch(Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                }
                return response;
            }
            
        }
        public Task<Book> GetBook(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.Books.FindAsync(id);
                
            }
        }

        public async Task DeleteBook(long bookId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var post = new Book() { Id = bookId };
                context.Books.Remove(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateBook(Book book)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {

                context.Books.Update(book);
                await context.SaveChangesAsync();
            }
        }
    }
}
