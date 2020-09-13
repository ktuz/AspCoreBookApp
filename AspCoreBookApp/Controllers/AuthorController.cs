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
    public class AuthorController : Controller
    {
        IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Route("page")]
        [HttpGet]
        public async Task<ActionResult> GetAuthors(int pageIndex)
        {
            var result = await _authorService.GetAuthors(pageIndex);
            return Ok(result);
        }

        [Route("post")]
        [HttpPost]
        public async Task AddAuthor([FromBody] AuthorDto request)
        {
            await _authorService.AddAuthor(request);
        }

        [Route("update")]
        [HttpPut]
        public async Task UpdateAuthor([FromBody] AuthorDto request)
        {
            await _authorService.UpdateAuthor(request);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task DeleteAuthor(long id)
        {
            await _authorService.DeleteAuthor(id);
        }

        [Route("list")]
        [HttpGet]
        public async Task<List<AuthorDto>> GetAuthors()
        {
            return await _authorService.GetAuthors();
        }

    }
}