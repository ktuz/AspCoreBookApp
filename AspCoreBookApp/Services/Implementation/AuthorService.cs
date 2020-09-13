using AspCoreBookApp.Helpers;
using AspCoreBookApp.Services.Interfaces;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data.Interfaces;
using Domain.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository _repository;
        IConfiguration _config;
        IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _config = configuration;
            _mapper = mapper;
        }
        public async Task<Page<AuthorDto>> GetAuthors(int pageIndex)
        {
            var pageSize = _config.GetValue<int>("pageSize");
            var page = await _repository.GetAuthors(pageIndex, pageSize);
            var result = _mapper.ToMappedPage<Author, AuthorDto>(page);
            return result;
        }
        public async Task AddAuthor(AuthorDto newAuthor)
        {
            var author = _mapper.Map<AuthorDto, Author>(newAuthor);
            await _repository.AddAuthor(author);
        }

        public async Task DeleteAuthor(long AuthorId)
        {
            await _repository.DeleteAuthor(AuthorId);
        }

        public async Task<List<AuthorDto>> GetAuthors()
        {
            var authors = await _repository.GetAuthors();

            var result = _mapper.Map<List<Author>,List<AuthorDto>>(authors);
            return result;
        }

        public async Task UpdateAuthor(AuthorDto author)
        {
            var result = _mapper.Map<AuthorDto, Author>(author);
            await _repository.UpdateAuthor(result);
        }
    }
}
