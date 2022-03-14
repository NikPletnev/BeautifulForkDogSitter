using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    internal class GetCustomerForTestExeptionTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var customerWithNoName = new CustomerModel
            {
                Id = 1,
                FirstName = "",
                LastName = "Ненадо",
                Address =
                new AddressModel
                {
                    Id = 1,
                    Name = "Не мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };
            var customerWithNoLastName = new CustomerModel
            {
                Id = 1,
                FirstName = "Дядя",
                LastName = "",
                Address =
                new AddressModel
                {
                    Id = 1,
                    Name = "Не мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };

            var customerWithNoContact = new CustomerModel
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
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { },
                Password = "admin",
                IsDeleted = false
            };

            var customerWithNoPassword = new CustomerModel
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
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "",
                IsDeleted = false
            };
            var customerEntity = new Customer
            {
                Id = 1,
                FirstName = "",
                LastName = "Ненадо",
                Address =
                new Address
                {
                    Id = 1,
                    Name = "Не мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false
            };


            yield return new object[] { customerWithNoName, customerEntity };
            yield return new object[] { customerWithNoLastName, customerEntity };
            yield return new object[] { customerWithNoContact, customerEntity };
            yield return new object[] { customerWithNoPassword, customerEntity };

        }
    }
}
