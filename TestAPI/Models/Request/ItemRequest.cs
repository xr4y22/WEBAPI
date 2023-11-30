namespace TestAPI.Models.Request
{
    public class ItemRequest
    {
       
      
        public string name { get; set; }
        public decimal? sellingprice { get; set; }

        public MItem getItem()
        {
            MItem item = new MItem();
            item.Name = this.name;
            item.SellingPrice = this.sellingprice;
            return item;
        }
    }

   
}
