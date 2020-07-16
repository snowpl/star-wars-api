namespace StarWars.Api.SharedKernel.Contracts
{
    public class PageRequest
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public PageRequest(){ }
        public PageRequest(int pageSize = 10, int pageNumber = 1)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
