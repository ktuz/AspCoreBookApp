using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core.Entities.Page
{
    public class Page<T>
    {

        public Page(IEnumerable<T> records)
        {
            Records = new List<T>(records);
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<T> Records { get; set; }

        public Page()   
        {
            Records = new List<T>();
        }

        

        public string SearchPropertyName { get; set; }
        public string SearchTerm { get; set; }
        
    }
}
