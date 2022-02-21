﻿using DogSitter.BLL.Models;
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
    public  class UpdateCustomerTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var customer = new CustomerModel
            {
                Id = 1,
                FirstName = "Дядя",
                LastName = "Ненадо",
                Address =
                new AddressModel
                {
                    Id = 1,
                    Name = "Не мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = 1,
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };
            var customerEntity = new Customer
            {
                Id = 1,
                FirstName = "Дядя",
                LastName = "Ненадо",
                Address =
                new Address
                {
                    Id = 1,
                    Name = "Не мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = 1,
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };


            yield return new object[] { customer, customerEntity };

        }
    }
}
