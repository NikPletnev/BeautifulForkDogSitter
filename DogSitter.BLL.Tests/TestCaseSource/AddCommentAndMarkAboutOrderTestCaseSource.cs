using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddCommentAndMarkAboutOrderTestCaseSource: IEnumerable
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

            int idSitter = sitter.Id;
            Order order = new Order()
            {
                Id = 3,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Completed,
                Sitter = sitter,
                //Comment = new Comment() { Id = 1, Text = "All right", Date = new DateTime(2000, 11, 11), IsDeleted = false },
                IsDeleted = false
            };

            int idOrder = order.Id;


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


            yield return new object[] { order, idOrder, idSitter, sitter, orders, orderModel };
        }
    }

}
