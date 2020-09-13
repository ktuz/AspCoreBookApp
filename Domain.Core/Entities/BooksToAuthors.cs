using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class BooksToAuthors
    {
        public long? BookId { get; set; }
        public long? AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
