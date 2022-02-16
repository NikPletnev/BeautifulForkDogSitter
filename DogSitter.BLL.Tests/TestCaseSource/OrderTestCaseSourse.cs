using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class OrderTestCaseSourse
    {
        public Order EditOrderStatusByOrderId() =>
           new Order()
           {
               Id = 1,
               OrderDate = new DateTime(2011, 11, 11),
               Status = Status.created,
               CommentId = 1,
               Price = 100,
               IsDeleted = false
           };

        public List<Order> GetOrders() =>
            new List<Order>()
            {
                new Order()
                {
                    Id = 2,
                    OrderDate = DateTime.Now,
                    Price = 100,
                    Status = Status.created,
                    Mark = 1,
                    IsDeleted = false
                },
                 new Order()
                {
                    Id = 3,
                    OrderDate = DateTime.Now,
                    Price = 100,
                    Status = Status.created,
                    Mark = 1,
                    IsDeleted = true
                }
            };
        public Order GetOrder() =>
            new Order()
            {
                Id = 4,
                OrderDate = DateTime.Now,
                Price = 100,
                Status = Status.created,
                Mark = 1,
                IsDeleted = false
            };
        public OrderModel GetOrderModel() =>
            new OrderModel()
            {
                Id = 4,
                OrderDate = DateTime.Now,
                Status = Status.created,
                Price = 100,
                Mark = 1,
            };
       
    }
}
