using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DogSitterContext _context;

        public OrderRepository(DogSitterContext context)
        {
            _context = context;
        }

        public void Add(Order order, Customer customer)
        {
            order.Customer = customer;
            if (customer.Orders == null)
            {
                customer.Orders = new List<Order>();
            }
            customer.Orders.Add(order);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetById(int id) =>
             _context.Orders.FirstOrDefault(x => x.Id == id);

        public List<Order> GetAll() =>
            _context.Orders.Where(d => !d.IsDeleted).ToList();

        public void Update(Order entity, Order order)
        {
            entity.OrderDate = order.OrderDate;
            entity.Price = order.Price;
            entity.Status = order.Status;
            entity.Mark = order.Mark;
            entity.Sitter = order.Sitter;
            entity.Comment = order.Comment;
            entity.SitterWorkTime = order.SitterWorkTime;
            _context.SaveChanges();
        }

        public void Update(Order order, bool isDeleted)
        {
             order.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public void EditOrderStatusByOrderId(Order order, int status)
        {
            order.Status = (Status)status;
            _context.SaveChanges();
        }

        public List<Order> GetAllOrdersBySitterId(int id) =>
                _context.Orders.Where(x => x.Sitter.Id == id).ToList();

        public List<Order> GetAllOrdersByCustomerId(int id) =>
                _context.Orders.Where(x => x.Customer.Id == id).ToList();
        public void LeaveCommentAndRateOrder(Order order, Order ratedOrder)
        {
            _context.Comments.Add(ratedOrder.Comment);
            order.Mark = ratedOrder.Mark;
            order.Comment = ratedOrder.Comment;
            _context.SaveChanges();
        }


    }
}
