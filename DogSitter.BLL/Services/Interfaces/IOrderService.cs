using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IOrderService
    {
        void Add(OrderModel orderModel);
        void DeleteById(int id);
        List<OrderModel> GetAll();
        OrderModel GetById(int id);
        void Restore(int id);
        void Update(OrderModel orderModel);
    }
}