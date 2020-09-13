using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Page<Author>> GetAuthors(int index, int pageSize);
        Task AddAuthor(Author author);
        Task DeleteAuthor(long AuthorId);
        Task UpdateAuthor(Author author);
        Task<Author> GetAuthor(long id);
        Task<List<Author>> GetAuthors();

    }
}
