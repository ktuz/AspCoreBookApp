using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class BookDto
    {
        public long? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PublisherID { get; set; }
        public PublisherDto Publisher { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedAt { get; set; }

        public List<AuthorDto> Authors { get; set; }
    }
}
