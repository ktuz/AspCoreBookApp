using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.Entities.Page;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreBookApp.Helpers
{
    public static class MappingExtensions
    {
        public static Page<TDestination> ToMappedPage<TSource, TDestination>(this IMapper mapper, Page<TSource> page)
        {
            IEnumerable<TDestination> sourceList = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(page?.Records);
            
            Page<TDestination> pagedResult = new Page<TDestination>(sourceList) { CurrentPage = page.CurrentPage, PageSize = page.PageSize, TotalPages = page.TotalPages, SearchPropertyName = page.SearchPropertyName, SearchTerm = page.SearchTerm};
            return pagedResult;
        }

    }
}
