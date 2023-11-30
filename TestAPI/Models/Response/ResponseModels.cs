using TestAPI.Models.Request;

namespace TestAPI.Models.Response
{
    public class ResponseModels<T> : PagingRequest  where T : class 
    {
        public ResponseModels() { }
        public ResponseModels(PagingRequest paging)
        {
            this.pageIndex = paging.pageIndex;
            this.pageSize = paging.pageSize;
        }
        public int totalCount { get; set; }
       // public int pageIndex { get; set; } = 0;

      //  public int pageSize { get; set; } = 20;

        public  List<T> data { get; set; }
    }

    public class DataItem()
    {
        public int? id { get; set; }
        public string name { get; set; }
        public  decimal? price { get; set; }

        public int? stock { get; set; }
        public int? sellingprice { get; set; }
    }
}
