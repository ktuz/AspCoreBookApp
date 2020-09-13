using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AuthorDto
    {
        public long? AuthorID { get; set; }
        public string Name { get; set; }

        public List<BooksToAuthorsDto> BooksToAuthors { get; set; }
    }
}
