using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class BooksToAuthorsDto
    {
        public long BookId { get; set; }
        public long? AuthorId { get; set; }

    }
}
