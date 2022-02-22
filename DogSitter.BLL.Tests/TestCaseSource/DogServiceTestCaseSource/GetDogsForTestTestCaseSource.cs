using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

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
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Password = "123456",
                    Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                    IsDeleted = false
                }
            };

            yield return new object[] { dog };

        }
    }
}
