﻿using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource.DogServiceTestCaseSource
{
    public  class UpdateAddressTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var dog = new Dog
            {
                Id = 1,
                Name = "TestDog",
                Age = 1,
                Weight = 1,
                Description = "TestDescr",
                Breed = "TetsBreed",
                IsDeleted = false,
                Customer = new Customer
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Password = "123456",
                    Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.phone } },
                    IsDeleted = false
                }
            };

            var dogToUpdate = new DogModel
            {
                Id = 1,
                Name = "TestDog",
                Age = 1,
                Weight = 1,
                Description = "TestDescr",
                Breed = "TetsBreed",
                IsDeleted = false,
                Customer = new CustomerModel
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Password = "123456",
                    Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.phone } },
                    IsDeleted = false
                }
            };

            int id = 1;


            yield return new object[] { id, dog, dogToUpdate };

        }
    }
}