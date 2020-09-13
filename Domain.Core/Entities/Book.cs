using System;
using System.Collections.Generic;

namespace Domain.Core.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedAt { get; set; }

        public List<BooksToAuthors> BooksToAuthors { get; set; }
    }
}

