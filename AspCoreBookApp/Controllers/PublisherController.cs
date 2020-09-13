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
    public class PublisherController : Controller
    {
        IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [Route("page")]
        [HttpGet]
        public async Task<Page<PublisherDto>> GetPublisher(int pageIndex)
        {
            return await _publisherService.GetPublishers(pageIndex);
        }

        [Route("post")]
        [HttpPost]
        public async Task Addpublisher([FromBody] PublisherDto request)
        {
            await _publisherService.AddPublisher(request);
        }

        [Route("update")]
        [HttpPut]
        public async Task Updatepublisher([FromBody] PublisherDto request)
        {
            await _publisherService.UpdatePublisher(request);
        }

        [Route("delete")]
        [HttpDelete]
        public async Task Deletepublisher(long id)
        {
            await _publisherService.DeletePublisher(id);
        }

        [Route("list")]
        [HttpGet]
        public async Task<List<PublisherDto>> GetPublishers()
        {
            return await _publisherService.GetPublishers();
        }
    }
}