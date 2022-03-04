using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddCommentAndMarkAboutOrderTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var sitter = new Sitter()
            {
                Id = 1,
                FirstName = "TestName",
                LastName = "TestLastName",
                Password = "qwe123",
                Information = "GOOD SITTER",
                IsDeleted = false
            };

            var sitterModel = new SitterModel()
            {
                Id = 1,
                FirstName = "TestName",
                LastName = "TestLastName",
                Password = "qwe123",
                Information = "GOOD SITTER",
                IsDeleted = false
            };

            int SitterId = sitter.Id;
            Order order = new Order()
            {
                Id = 3,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Completed,
                Sitter = sitter,
                IsDeleted = false
            };

            int OrderId = order.Id;


            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Completed,
                    Price = 100,
                    Sitter = sitter,
                    Mark = 2,
                    IsDeleted = false
                },

                new Order()
                {
                     Id = 2,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.Completed,
                     Price = 100,
                     Sitter= sitter,
                     Mark= 3,
                     IsDeleted = false
                }
            };

            var orderModel = new OrderModel()
            {
                Id = 3,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Completed,
                Price = 100,
                Sitter = sitterModel,
                Mark = 3,
                IsDeleted = false
            };


            yield return new object[] { order, OrderId, SitterId, sitter, orders, orderModel };
        }
    }

}
