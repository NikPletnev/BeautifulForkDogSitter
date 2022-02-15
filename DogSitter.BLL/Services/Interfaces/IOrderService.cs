using DogSitter.BLL.Models;

namespace DogSitter.BLL.Services
{
    public interface IOrderService
    {
        void UpdateOrder(int id, OrderModel order);
    }
}