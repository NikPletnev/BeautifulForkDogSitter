using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IOrderService
    {
        void Add(OrderModel orderModel);
        void DeleteById(OrderModel orderModel);
        List<OrderModel> GetAll();
        OrderModel GetById(int id);
        void Restore(OrderModel orderModel);
        void Update(OrderModel orderModel);
        void EditOrderStatusByOrderId(int id, int status);
    }
}