﻿using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class AddCustomerAddressTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Password = "123456",
                    FirstName = "Iakov",
                    LastName = "Hohland",
                    Address = new List<Address>(),
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 2,
                    Password = "123456",
                    FirstName = "Brat",
                    LastName = "Dva",
                    Address = new List<Address>(),
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 3,
                    Password = "123456",
                    FirstName = "Nobody",
                    LastName = "Deleted",
                    Address = new List<Address>(),
                    IsDeleted = true
                }

            };

            var customerWithEmptyAddress = new Customer
            {
                Id = 2,
                Password = "123456",
                FirstName = "Brat",
                LastName = "Dva",
                IsDeleted = false
            };

            var address = new Address
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false
            };

            var expected = new Customer
            {
                Id = 2,
                Password = "123456",
                FirstName = "Brat",
                LastName = "Dva",
                Address = new List<Address>() { address },
                IsDeleted = false
            };

            yield return new object[] { customers, customerWithEmptyAddress, expected, address };

        }
    }
}