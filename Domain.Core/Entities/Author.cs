using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BooksToAuthors> BooksToAuthors { get; set; }
    }
}
