using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<Page<PublisherDto>> GetPublishers(int pageIndex);
        Task AddPublisher(PublisherDto publisher);
        Task UpdatePublisher(PublisherDto publisher);
        Task DeletePublisher(long PublisherId);
        Task<List<PublisherDto>> GetPublishers();
    }
}
