using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void EditOrderStatusByOrderId(Order order, int status);
        List<Order> GetAll();
        Order GetById(int id);
        void Update(Order entity, Order order);
        void Update(Order order, bool IsDeleted);
    }
}