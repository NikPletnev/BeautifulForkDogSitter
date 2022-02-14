using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void EditOrderStatusByOrderId(int id, int status);
        List<Order> GetAll();
        Order GetById(int id);
        void Update(int id, bool IsDeleted);
        void Update(Order order);
    }
}