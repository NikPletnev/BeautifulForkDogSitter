﻿using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class OrderTestCaseSourse
    {
        public static List<Order> GetOrders() =>
            new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.Now,
                    Price = 100,
                    Status = Status.created,
                    Mark = 5,
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
                    Dogs = new List<Dog>(),
                    Service = new List<Serviсe>(),
                    IsDeleted = false
                },
                new Order()
                {
                    Id = 2,
                    OrderDate = DateTime.Now,
                    Price = 301,
                    Status = Status.created,
                    Mark = 5,
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
                    Dogs = new List<Dog>(),
                    Service = new List<Serviсe>(),
                    IsDeleted = true
                }
            };
        public static Order GetOrder() =>
            new Order()
            {
                Id = 3,
                OrderDate = DateTime.Now,
                Price = 303,
                Status = Status.created,
                Mark = 1,
                Customer = new Customer()
                {
                    FirstName = " ",
                    LastName = " ",
                    Password = " "
                },
                Sitter = new Sitter()
                {
                    FirstName = " ",
                    LastName = " ",
                    Password = " "
                },
                Comment = new Comment() 
                {
                    Text = " " 
                },
                Dogs = new List<Dog>(),
                Service = new List<Serviсe>(),
                IsDeleted = false
            };

        public static Order GetOrderByUpdate() =>
            new Order()
            {
                Id = 3,
                OrderDate = DateTime.Now,
                Price = 303,
                Status = Status.created,
                Mark = 1,
                Sitter = new Sitter()
                {
                    FirstName = " ",
                    LastName = " ",
                    Password = " "
                },
                Comment = new Comment()
                {
                    Text = " "
                },
                IsDeleted = false
            };
        public static Order GetEditOrderStatus() =>
             new Order()
             {
                 Id = 4,
                 OrderDate = DateTime.Now,
                 Price = 303,
                 Status = Status.created,
                 Mark = 1,
                 Sitter = new Sitter()
                 {
                     FirstName = " ",
                     LastName = " ",
                     Password = " "
                 },
                 Comment = new Comment()
                 {
                     Text = " "
                 },
                 IsDeleted = false
             };
    }
}
