using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class CustomerWithNewCustomerTestCaseSource : IEnumerable
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
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 2,
                    Password = "123456",
                    FirstName = "Brat",
                    LastName = "Dva",
                    IsDeleted = false
                },
                new Customer
                {
                    Id = 3,
                    Password = "123456",
                    FirstName = "Nobody",
                    LastName = "Deleted",
                    IsDeleted = true
                }

            };

            var newCustomer = new Customer
            {
                Id = 2,
                Password = "123456",
                FirstName = "Brat",
                LastName = "Dva",
            };

            var expected = new Customer
            {
                Id = 2,
                Password = "123456",
                FirstName = "Brat",
                LastName = "Dva",
                IsDeleted = false
            };

            yield return new object[] { customers, newCustomer, expected };
        }
    }
}


