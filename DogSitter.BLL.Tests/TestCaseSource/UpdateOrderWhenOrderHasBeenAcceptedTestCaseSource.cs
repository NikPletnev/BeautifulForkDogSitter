using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    internal class UpdateOrderWhenOrderHasBeenAcceptedTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;

            Order order = new Order()
            {
                Id = 2,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Accepted,
                CommentId = 1,
                Price = 100,
                IsDeleted = false,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "qqq",
                    LastName = "www",
                    Password = "12324"
                }
            };

            OrderModel model = new OrderModel()
            {
                Id = 2,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                Price = 100,
                IsDeleted = false,
                Customer = new CustomerModel()
                {
                    Id = 1,
                    FirstName = "qqq",
                    LastName = "www",
                    Password = "12324"
                }
            };

            yield return new object[] { id, order, model };
        }
    }
}
