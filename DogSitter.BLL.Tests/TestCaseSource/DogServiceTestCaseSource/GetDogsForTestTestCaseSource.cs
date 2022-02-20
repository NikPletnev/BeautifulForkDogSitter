using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource.DogService
{
    public class GetDogsForTestTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var dog = new DogModel
            {
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

            yield return new object[] { dog };

        }
    }
}
