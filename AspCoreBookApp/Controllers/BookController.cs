using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreBookApp.Services.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBookApp.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [Route("page")]
        [HttpGet]
        public async Task<Page<BookDto>> GetBooks(int pageIndex, string SearchPropertyName = "", string SearchTerm = "")
        {
            return await _bookService.GetBooks(pageIndex, SearchPropertyName, SearchTerm);
        }

        [Route("post")]
        [HttpPost]
        public async Task AddBook([FromBody] BookDto request)
        {
            await _bookService.AddBook(request);
        }

        [Route("update")]
        [HttpPut]
        public async Task UpdateAuthor([FromBody] BookDto request)
        {
            await _bookService.UpdateBook(request);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task DeleteBook(long id)
        {
            await _bookService.DeleteBook(id);
        }

    }
}