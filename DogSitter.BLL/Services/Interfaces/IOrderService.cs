using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services.Interface
{
    public interface IOrderService
    {
        void Add(OrderModel orderModel);
        void AddCommentAndMarkAboutOrder(int id, OrderModel order);
        void DeleteById(int id);
        void EditOrderStatusByOrderId(int id, int status);
        List<OrderModel> GetAll();
        List<OrderModel> GetAllOrdersByCustomerId(int id);
        List<OrderModel> GetAllOrdersBySitterId(int id);
        OrderModel GetById(int id);
        void Restore(int id);
        void Update(OrderModel orderModel);
    }
}