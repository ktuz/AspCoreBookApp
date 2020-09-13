using Domain.Core.Entities.Page;
using Domain.Data.Helpers;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<Page<BookDto>> GetBooks(int index, string SearchPropertyName = "", string SearchTerm = "");
        Task<BookDto> GetBook(long id);
        Task AddBook(BookDto newBook);
        Task DeleteBook(long id);
        Task UpdateBook(BookDto newBook);
        Task<ServiceResponse<BookDto>> AddBookToAuthor(BooksToAuthorsDto newBookToAuthor);
    }
}
