using TestAPI.TestAPIEntity;

namespace TestAPI.Interface
{
    public class OrderDataAccess : IOrderDataAccess
    {
        public List<OrderModel> GetAllOrder()
        {
            using (var context = new OrderDbContext())
            {
                return context.OrderData.ToList();
            }
        }
        public void SaveOrder(OrderModel order)
        {
            using (var context = new OrderDbContext())
            {
                context.Add<OrderModel>(order);
                context.SaveChanges();
            }
        }
    }
}
