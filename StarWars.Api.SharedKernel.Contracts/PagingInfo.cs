namespace StarWars.Api.SharedKernel.Contracts
{
    public class PagingInfo
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public PagingInfo(int pageNumber, int pageSize, int totalCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
