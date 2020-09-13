using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<Page<AuthorDto>> GetAuthors(int pageIndex);
        Task AddAuthor(AuthorDto authorView);
        Task UpdateAuthor(AuthorDto authorView);
        Task DeleteAuthor(long AuthorId);
        Task<List<AuthorDto>> GetAuthors();
    }
}
