using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory)
        { }

        public async Task<Page<Author>> GetAuthors(int index, int pageSize)
        {
            var result = new Page<Author>() { CurrentPage = index, PageSize = pageSize};

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Authors.AsQueryable();
                result.TotalPages = await query.CountAsync();
                result.Records = await query.OrderBy(c => c.Name).Skip(index * pageSize).Take(pageSize).OrderByDescending(c=>c.Id).ToListAsync();
            }
            return result;
        }

        public async Task AddAuthor(Author author)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var dbr = await context.Authors.Where(c => c.Name == author.Name).CountAsync();
                if(dbr==0)
                {
                    context.Authors.Add(author);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteAuthor(long AuthorId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var author = new Author() { Id = AuthorId };
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }
        }
        public async Task<List<Author>> FindAuthor(string AuthorName)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Authors.Where(x=> AuthorName.Contains(x.Name)).ToListAsync();
            }
        }

        public async Task<Author> GetAuthor(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Authors.FindAsync(id);
            }
        }

        public async Task<List<Author>> GetAuthors()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Authors.ToListAsync();
            }
        }

        public async Task UpdateAuthor(Author author)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Authors.Update(author);
                await context.SaveChangesAsync();

            }
        }
    }
}
