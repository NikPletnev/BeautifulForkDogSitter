using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogSitter.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DogSitterContext _context;

        public OrderRepository(DogSitterContext context)
        {
            _context = context;
        }

        public int Add(Order order, Customer customer)
        {
            order.Customer = customer;
            if (customer.Orders == null)
            {
                customer.Orders = new List<Order>();
            }
            customer.Orders.Add(order);
            var orderId = _context.Orders.Add(order);
            _context.SaveChanges();
            return orderId.Entity.Id;
        }

        public Order GetById(int id) =>
             _context.Orders.Where(x => x.Id == id)
            .Include(w => w.Customer)
            .Include(w => w.Service)
            .Include(w => w.Sitter)
            .Include(w => w.SitterWorkTime)
            .FirstOrDefault();

        public List<Order> GetAll() =>
            _context.Orders.Where(d => !d.IsDeleted).ToList();

        public void Update(Order entity)
        {
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
