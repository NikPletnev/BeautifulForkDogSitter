using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IOrderRepository
    {
        int Add(Order order, Customer customer);
        void EditOrderStatusByOrderId(Order order, int status);
        List<Order> GetAll();
        List<Order> GetAllOrdersByCustomerId(int id);
        List<Order> GetAllOrdersBySitterId(int id);
        Order GetById(int id);
        void LeaveCommentAndRateOrder(Order order, Order ratedOrder);
        void Update(Order entity);
    }
}