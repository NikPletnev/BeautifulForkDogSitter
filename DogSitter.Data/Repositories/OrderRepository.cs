﻿using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;

namespace DogSitter.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DogSitterContext _context;

        public OrderRepository(DogSitterContext context)
        {
            _context = context;
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

        public void Update(Order entity, Order order)
        {
            entity.OrderDate = order.OrderDate;
            entity.Price = order.Price;
            entity.Status = order.Status;
            entity.Mark = order.Mark;
            entity.Sitter = order.Sitter;
            entity.Comment = order.Comment;
            _context.SaveChanges();
        }

        public void Update(Order order, bool IsDeleted)
        {
            order.IsDeleted = IsDeleted;
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

    }
}
