using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data.Helpers;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<Page<Book>> GetBooks(int index, int pageSize, string SearchPropertyName = "", string SearchTerm = "");
        Task<Book> GetBook(long id);
        Task AddBook(Book newBook);
        Task UpdateBook(Book book);
        Task DeleteBook(long bookId);
        Task<ServiceResponse<Book>> AddBookToAuthor(BooksToAuthors newBookToAuthor);
    }
}
