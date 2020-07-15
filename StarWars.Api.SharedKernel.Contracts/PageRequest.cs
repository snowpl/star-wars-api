namespace StarWars.Api.SharedKernel.Contracts
{
    public abstract class PageRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public PageRequest(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
