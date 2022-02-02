using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Repositories
{
    public class OrderRepository
    {
        private DogSitterContext _context;

        public OrderRepository()
        {
            _context = DogSitterContext.GetInstance();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetById(int id) =>
             _context.Orders.FirstOrDefault(x => x.Id == id);

        public List<Order> GetAll() =>
            _context.Orders.Where(d => !d.IsDeleted).ToList();

        public void Update(Order order)
        {
            var entity = GetById(order.Id);
            entity.OrderDate = order.OrderDate;
            entity.Price = order.Price;
            entity.Status = order.Status;
            entity.Mark = order.Mark;
            entity.Sitter = order.Sitter;
            entity.Comment = order.Comment;
            _context.SaveChanges();
        }

        public void Update(int id, bool IsDeleted)
        {
            Order order = GetById(id);
            order.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
