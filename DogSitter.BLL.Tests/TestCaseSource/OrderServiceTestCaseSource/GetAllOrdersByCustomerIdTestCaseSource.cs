using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllOrdersByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            Customer customer = new Customer()
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                IsDeleted = false,
                Role = Role.Customer,
                Orders = new List<Order>()
                {
                    new Order()
                    {
                        Id = 1,
                        OrderDate = new DateTime(2011, 11, 11),
                        Status = Status.Created,
                        Price = 100,
                        IsDeleted = false
                    },

                    new Order()
                    {
                        Id = 2,
                        OrderDate = new DateTime(2011, 11, 11),
                        Status = Status.Created,
                        Price = 100,
                        IsDeleted = false
                    }

                }
            };


            int id = 1;

            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Created,
                    Price = 100,
                    IsDeleted = false
                },

                new Order()
                {
                     Id = 2,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.Created,
                     Price = 100,
                     IsDeleted = false
                }
            };


            yield return new object[] { id, customer, orders };
        }
    }
}