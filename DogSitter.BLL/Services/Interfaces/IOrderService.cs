using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        int Add(int userId, OrderModel orderModel);
        void EditOrderStatusByOrderId(int userId, int id, int status);
        List<OrderModel> GetAllOrdersByCustomerId(int userId, int id);
        List<OrderModel> GetAllOrdersBySitterId(int userId, int id);
        void Update(int userId, OrderModel orderModel);
        void AddCommentAndMarkAboutOrder(int id, OrderModel order);
        OrderModel GetOrderById(int id);
    }
}