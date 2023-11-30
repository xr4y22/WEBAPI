using TestAPI.TestAPIEntity;

namespace TestAPI.Interface
{
    public interface IOrderDataAccess
    {
        List<OrderModel> GetAllOrder();

        void SaveOrder(OrderModel order);
    }
}
