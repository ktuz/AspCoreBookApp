using AspCoreBookApp.Helpers;
using AspCoreBookApp.Services.Interfaces;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data.Helpers;
using Domain.Data.Interfaces;
using Domain.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Services.Implementation
{
    public class BookService : IBookService
    {
        IBookRepository _repository;
        IConfiguration _config;
        IMapper _mapper;

        public BookService(IBookRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _config = configuration;
            _mapper = mapper;
        }

        public async Task<Page<BookDto>> GetBooks(int pageIndex, string SearchPropertyName = "", string SearchTerm = "")
        {
            var pageSize = _config.GetValue<int>("pageSize");
            var page = await _repository.GetBooks(pageIndex, pageSize, SearchPropertyName, SearchTerm);
            var result = _mapper.ToMappedPage<Book, BookDto>(page);
           return result;
        }

        public async Task AddBook(BookDto newBook)
        {
            var author = _mapper.Map<BookDto, Book>(newBook);
            await _repository.AddBook(author);
        }

        public Task<ServiceResponse<BookDto>> AddBookToAuthor(BooksToAuthorsDto newBookToAuthor)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBook(long id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBook(BookDto newBook)
        {
            var result = _mapper.Map<BookDto, Book>(newBook);
            await _repository.UpdateBook(result);
        }

        public async Task DeleteBook(long id)
        {
            await _repository.DeleteBook(id);
        }
    }
}
