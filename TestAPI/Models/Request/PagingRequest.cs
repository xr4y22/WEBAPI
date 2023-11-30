using TestAPI.Models.Response;

namespace TestAPI.Models.Request
{
    public class PagingRequest
    {
        public int pageIndex { get; set; } = 0;
        public int pageSize { get; set; } = 20;
  
    }
}
