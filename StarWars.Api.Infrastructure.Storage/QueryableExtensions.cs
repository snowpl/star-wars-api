using Microsoft.EntityFrameworkCore;
using StarWars.Api.SharedKernel.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Infrastructure.Storage
{
    public static class QueryableExtensions
    {
        public static async Task<PageResponse<TResult>> PickPage<TResult>(this IQueryable<TResult> input, PageRequest query)
            =>  new PageResponse<TResult>(input.Skip((query.PageNumber-1) * query.PageSize).Take(query.PageSize).ToList(),
                CreatePagingInfo(query, input.Count()));

        public static async Task<PageResponse<TResult>> PickPage<TResult>(this IEnumerable<TResult> input, PageRequest query)
        {
            var data = input.ToList();
            return new PageResponse<TResult>(data.Skip((query.PageNumber-1) * query.PageSize).Take(query.PageSize).ToList(),
                CreatePagingInfo(query, data.Count));
        }

        private static PagingInfo CreatePagingInfo(PageRequest query, int totalCount)
            => new PagingInfo(query.PageNumber, query.PageSize, totalCount);
            
    }
}
