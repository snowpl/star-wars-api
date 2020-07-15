using StarWars.Api.SharedKernel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Api.Infrastructure
{
    public class PageResponse<TResult> 
    {
        public IReadOnlyCollection<TResult> Results { get; }
        public PagingInfo PagingInfo { get; }

        public PageResponse(IReadOnlyCollection<TResult> results, PagingInfo pagingInfo)
        {
            Results = results;
            PagingInfo = pagingInfo;
        }
    }
}
