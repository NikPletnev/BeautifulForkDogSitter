using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddOrderTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            OrderModel orderModel = new OrderModel()
            {
                Id = 1,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                IsDeleted = false,

                Sitter = new SitterModel(),
                Price = 1000,
                Services = new List<ServiceModel>()
                {
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 100,
                    }
                }
            };

            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            int id = 1;

            var expected = new OrderModel()
            {
                Id = 1,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                IsDeleted = false,
                Sitter = new SitterModel(),
                Price = 1000,
                Services = new List<ServiceModel>()
                {
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 300,
                    },
                    new ServiceModel()
                    {
                        Price = 100,
                    }
                },
                Customer = new CustomerModel
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Password = "123456",
                    Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                    IsDeleted = false
                }
            };

            yield return new object[] { orderModel, customer, id, expected };
        }

    }
}
