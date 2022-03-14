using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetCustomersForTestTestCaseSource : IEnumerable
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
                    House = "3",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };

            yield return new object[] { customer };
        }
    }
}

