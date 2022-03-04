using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class OrderTestCaseSourse
    {
        public Order EditOrderStatusByOrderId() =>
           new Order()
           {
               Id = 1,
               OrderDate = new DateTime(2011, 11, 11),
               Status = Status.Created,
               CommentId = 1,
               Price = 100,
               Customer = new Customer()
               {
                   FirstName = "",
                   LastName = " ",
                   Password = " "
               },
               Sitter = new Sitter()
               {
                   FirstName = "",
                   LastName = " ",
                   Password = " "
               },
               Comment = new Comment()
               {
                   Text = " "
               },
               Dog = new Dog()
               {
                   Name = " ",
                   Age = 2,
                   Breed = " ",
                   Weight = 1,
                   Description = " "
               },
               Service = new List<Serviсe>(),
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
                    Status = Status.Created,
                    Mark = 1, Customer = new Customer()
                    {
                        FirstName = "",
                        LastName = " ",
                        Password = " "
                    },
                    Sitter = new Sitter()
                    {
                        FirstName = "",
                        LastName = " ",
                        Password = " "
                    },
                    Comment = new Comment()
                    {
                        Text = " "
                    },
                    Dog = new Dog()
                    {
                        Name = " ",
                        Age = 2,
                        Breed = " ",
                        Weight = 1,
                        Description = " "
                    },
                    Service = new List<Serviсe>(),
                    IsDeleted = false
                },
                 new Order()
                {
                    Id = 3,
                    OrderDate = DateTime.Now,
                    Price = 100,
                    Status = Status.Created,
                    Mark = 1, Customer = new Customer()
                    {
                        FirstName = "",
                        LastName = " ",
                        Password = " "
                    },
                    Sitter = new Sitter()
                    {
                        FirstName = "",
                        LastName = " ",
                        Password = " "
                    },
                    Comment = new Comment()
                    {
                        Text = " "
                    },
                    Dog = new Dog()
                    {
                        Name = " ",
                        Age = 2,
                        Breed = " ",
                        Weight = 1,
                        Description = " "
                    },
                    Service = new List<Serviсe>(),
                    IsDeleted = true
                }
            };
        public Order GetOrder() =>
            new Order()
            {
                Id = 4,
                OrderDate = DateTime.Now,
                Price = 100,
                Status = Status.Created,
                Mark = 1,
                IsDeleted = false
            };
        public OrderModel GetOrderModel() =>
            new OrderModel()
            {
                Id = 4,
                OrderDate = DateTime.Now,
                Status = Status.Created,
                Price = 100,
                Mark = 1,
                Customer = new CustomerModel()
                {
                    FirstName = "",
                    LastName = " ",
                    Password = " "
                },
                Sitter = new SitterModel()
                {
                    FirstName = "",
                    LastName = " ",
                    Password = " "
                },
                Comment = new CommentModel()
                {
                    Text = " "
                },
                Dog = new DogModel()
                {
                    Name = " ",
                    Age = 2,
                    Breed = " ",
                    Weight = 1,
                    Description = " "
                },
                Services = new List<ServiceModel>(),
            };

    }
}
