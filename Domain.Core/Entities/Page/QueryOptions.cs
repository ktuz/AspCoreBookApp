using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities.Page
{
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string SearchPropertyName { get; set; }
        public string SearchTerm { get; set; }
    }
}
