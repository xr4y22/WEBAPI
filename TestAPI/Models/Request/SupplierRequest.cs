namespace TestAPI.Models.Request
{
    public class SupplierRequest
    {
        public string name { get; set; }

        public MSupplier getItem()
        {
            MSupplier item = new MSupplier();
            item.Name = this.name;

            return item;
        }
    }
}
