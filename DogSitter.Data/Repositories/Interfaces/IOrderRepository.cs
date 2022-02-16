using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void EditOrderStatusByOrderId(Order order, int status);
        List<Order> GetAll();
        Order GetById(int id);
        void Update(Order order, bool IsDeleted);
        void Update(Order order);
    }
}