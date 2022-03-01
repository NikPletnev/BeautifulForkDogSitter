using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllSittersOrdersTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {


            var sitter = new Sitter()
            {
                Id = 1111,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                Contacts = new List<Contact>() { new Contact { Id = 1, Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    Id = 11,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Completed,
                    Price = 100,
                    Mark = 2,
                    CommentId = 11,
                    Comment = new Comment(){ Id= 11, Text = "Cumment", Date = new DateTime(2021, 10, 11)},
                    Sitter = sitter,
                    IsDeleted = false
                },

                new Order()
                {
                     Id = 22,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.Completed,
                     Price = 100,
                     Mark = 3,
                     CommentId = 22,
                     Comment = new Comment(){Id= 22, Text = "Cumment", Date = new DateTime(2021, 10, 11)},
                     Sitter = sitter,
                     IsDeleted = false
                },

                new Order()
                {
                     Id = 33,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.CanceledByAdmin,
                     Price = 100,
                     IsDeleted = false
                },

                new Order()
                {
                     Id = 44,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.CanceledBySitter,
                     Price = 100,
                     IsDeleted = false
                },

            };


            List<Order> ordersExpected = new List<Order>()
            {
                new Order()
                {
                    Id = 11,
                    OrderDate = new DateTime(2011, 11, 11),
                    Status = Status.Completed,
                    Price = 100,
                    Mark = 2,
                    CommentId = 11,
                    Comment = new Comment(){Id= 11,  Text = "Cumment", Date = new DateTime(2021, 10, 11)},
                    Sitter = sitter,
                    IsDeleted = false
                },

                new Order()
                {
                     Id = 22,
                     OrderDate = new DateTime(2011, 11, 11),
                     Status = Status.Completed,
                     Price = 100,
                     Mark = 3,
                     CommentId = 22,
                     Comment = new Comment(){Id= 22, Text = "Cumment", Date = new DateTime(2021, 10, 11)},
                     Sitter = sitter,
                     IsDeleted = false
                }
            };

            yield return new object[] { orders, ordersExpected, sitter };
        }
    }

}
