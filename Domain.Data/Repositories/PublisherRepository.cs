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
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {
        public PublisherRepository(string connectionString, IRepositoryContextFactory contextFactory)
           : base(connectionString, contextFactory)
        { }

        public async Task<Page<Publisher>> GetPublishers(int index, int pageSize)
        {
            var result = new Page<Publisher>() { CurrentPage = index, PageSize = pageSize };

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Publishers.AsQueryable();
                result.TotalPages = await query.CountAsync();
                result.Records = await query.OrderBy(c => c.Name).Skip(index * pageSize).Take(pageSize).OrderByDescending(c => c.Id).ToListAsync();
            }
            return result;
        }

        public async Task AddPublisher(Publisher publisher)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var dbr = await context.Publishers.Where(c => c.Name == publisher.Name).CountAsync();
                if (dbr == 0)
                {
                    context.Publishers.Add(publisher);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeletePublisher(long publisherId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var publisher = new Publisher() { Id = publisherId };
                context.Publishers.Remove(publisher);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Publisher> GetPublisher(long id)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Publishers.FindAsync(id);
            }
        }

        public async Task<List<Publisher>> GetPublishers()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Publishers.ToListAsync();
            }
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                context.Publishers.Update(publisher);
                await context.SaveChangesAsync();
            }
        }
    }
}
