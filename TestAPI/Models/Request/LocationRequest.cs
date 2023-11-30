namespace TestAPI.Models.Request
{
    public class LocationRequest
    {
        public string name { get; set; }

        public MLocation getItem()
        {
            MLocation item = new MLocation();
            item.Name = this.name;
            
            return item;
        }
    }
}
