using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllComentsBySitterIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Sitter sitter = new Sitter()
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                IsDeleted = false,
            };

            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Created,
                    CommentId = 1,
                    Price = 100,
                    IsDeleted = false,
                    Comment = new Comment()
                    {
                        Id = 4,
                        Text = "Privet1",
                        Date = new DateTime(1999, 11, 11),
                        IsDeleted = false,
                    },
                    Sitter = sitter
                },

                new Order()
                {
                    Id = 2,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Created,
                    CommentId = 2,
                    Price = 100,
                    IsDeleted = false,
                    Comment = new Comment()
                    {
                        Id = 5,
                        Text = "Privet2",
                        Date = new DateTime(1999, 1, 1),
                        IsDeleted = false,
                    },
                    Sitter = sitter
                },

                new Order()
                {
                    Id = 3,
                    OrderDate = new DateTime(2011, 10, 10),
                    Status = Status.Created,
                    CommentId = 3,
                    Price = 100,
                    IsDeleted = false,
                    Comment = new Comment()
                    {
                        Id = 3,
                        Text = "Privet3",
                        Date = new DateTime(2011, 10, 13),
                        IsDeleted = false,
                    },
                    Sitter = new Sitter()
                    {
                        Id = 3,
                        FirstName = "Test3",
                        LastName = "Test3",
                        Password = "strong3" ,
                        IsDeleted = false ,
                    },
                }
            };

            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = 4,
                    Text = "Privet1",
                    Date = new DateTime(1999, 11, 11),
                    IsDeleted = false,
                    Order = new Order()
                    {
                        Id = 1,
                        OrderDate = new DateTime(2011, 11, 11),
                        Status = Status.Created,
                        CommentId = 1,
                        Price = 100,
                        IsDeleted = false,
                        Sitter = sitter
                    }
                },
                new Comment()
                {
                    Id = 5,
                    Text = "Privet2",
                    Date = new DateTime(1999, 1, 1),
                    IsDeleted = false,
                    Order = new Order()
                    {
                        Id = 2,
                        OrderDate = new DateTime(2011, 11, 11),
                        Status = Status.Created,
                        CommentId = 2,
                        Price = 100,
                        IsDeleted = false,
                        Sitter= sitter
                    }
                }
            };

            int id = 1;

            yield return new Object[] { orders, id, comments };
        }
    }
}

