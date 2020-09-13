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
    public class PublisherService : IPublisherService
    {
        IPublisherRepository _repository;
        IConfiguration _config;
        IMapper _mapper;

        public PublisherService(IPublisherRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _config = configuration;
            _mapper = mapper;
        }

        public async Task<Page<PublisherDto>> GetPublishers(int pageIndex)
        {
            var pageSize = _config.GetValue<int>("pageSize");
            var page = await _repository.GetPublishers(pageIndex, pageSize);
            var result = _mapper.ToMappedPage<Publisher, PublisherDto>(page);
            return result;
        }
        public async Task AddPublisher(PublisherDto newAuthor)
        {
            var author = _mapper.Map<PublisherDto, Publisher>(newAuthor);
            await _repository.AddPublisher(author);
        }

        public async Task DeletePublisher(long PublisherId)
        {
            await _repository.DeletePublisher(PublisherId);
        }

        public async Task<List<PublisherDto>> GetPublishers()
        {
            var authors = await _repository.GetPublishers();

            var result = _mapper.Map<List<Publisher>, List<PublisherDto>>(authors);
            return result;
        }

        public async Task UpdatePublisher(PublisherDto publisher)
        {
            var result = _mapper.Map<PublisherDto, Publisher>(publisher);
            await _repository.UpdatePublisher(result);
        }
    }
}
