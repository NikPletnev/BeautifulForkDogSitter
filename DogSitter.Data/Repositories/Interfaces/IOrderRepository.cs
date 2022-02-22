using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void EditOrderStatusByOrderId(Order order, int status);
        List<Order> GetAll();
        List<Order> GetAllOrdersByCustomerId(int id);
        List<Order> GetAllOrdersBySitterId(int id);
        Order GetById(int id);
        void LeaveCommentAndRateOrder(Order order, Order ratedOrder);
        void Update(Order entity, Order order);
    }
}