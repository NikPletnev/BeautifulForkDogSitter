using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests
{
    public class GetAllOrdersByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "Test1",
                    LastName = "Test1",
                    Password = "strong" ,
                    IsDeleted = false,
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
                    },
                },
                new Customer()
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Иванов2",
                    Password = "2strong",
                    IsDeleted = false,
                    Orders= new List<Order>()
                    {
                        new Order()
                        {
                            Id = 3,
                            OrderDate = new DateTime(2011, 1, 1),
                            Status = Status.CanceledByAdmin,
                            Price = 100,
                            IsDeleted = false
                        }
                    }
                },
                new Customer()
                {
                    Id = 3,
                    FirstName = "Test3",
                    LastName = "Иванов2",
                    Password = "veryStrong",
                    IsDeleted = true,
                    Orders= new List<Order>(){ }
                }
            };

            int id1 = 1;

            List<Order> orders1 = new List<Order>()
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

            int id2 = 2;

            List<Order> orders2 = new List<Order>()
            {
                new Order()
                {
                    Id = 3,
                    OrderDate = new DateTime(2011, 1, 1),
                    Status = Status.CanceledByAdmin,
                    Price = 100,
                    IsDeleted = false
                }
            };

            int id3 = 3;

            List<Order> orders3 = new List<Order>() { };


            yield return new object[] { id1, customers, orders1 };
            yield return new object[] { id2, customers, orders2 };
            yield return new object[] { id3, customers, orders3 };


        }
    }
}