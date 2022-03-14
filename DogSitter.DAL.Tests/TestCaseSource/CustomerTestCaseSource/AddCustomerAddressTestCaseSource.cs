using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

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
                    Address = new Address(),
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 2,
                    Password = "123456",
                    FirstName = "Brat",
                    LastName = "Dva",
                    Address = new Address(),
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 3,
                    Password = "123456",
                    FirstName = "Nobody",
                    LastName = "Deleted",
                    Address = new Address(),
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
                House = "3",
                Apartament = 1,
                IsDeleted = false
            };

            var expected = new Customer
            {
                Id = 2,
                Password = "123456",
                FirstName = "Brat",
                LastName = "Dva",
                Address = address,
                IsDeleted = false
            };

            yield return new object[] { customers, customerWithEmptyAddress, expected, address };

        }
    }
}