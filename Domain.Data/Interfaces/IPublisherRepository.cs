using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Interfaces
{
    public interface IPublisherRepository
    {
        Task<Page<Publisher>> GetPublishers(int index, int pageSize);
        Task AddPublisher(Publisher publisher);
        Task DeletePublisher(long publisherId);
        Task UpdatePublisher(Publisher publisher);
        Task<Publisher> GetPublisher(long id);
        Task<List<Publisher>> GetPublishers();
        
    }
}
