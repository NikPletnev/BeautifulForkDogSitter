using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services.Interface
{
    public interface IOrderService
    {
        void Add(int userId, OrderModel orderModel);
        void EditOrderStatusByOrderId(int userId, int id, int status);
        List<OrderModel> GetAllOrdersByCustomerId(int userId, int id);
        List<OrderModel> GetAllOrdersBySitterId(int userId, int id);
        void Update(int userId, OrderModel orderModel);
    }
}