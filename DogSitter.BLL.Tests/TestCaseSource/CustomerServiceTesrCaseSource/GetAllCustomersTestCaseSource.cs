using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllCustomersTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {


            CustomerModel customer = new CustomerModel
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            var customers = new List<Customer>
            {
                new Customer()
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
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<Contact>() { new Contact{ Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false,

                },
                new Customer()
                {
                Id = 2,
                FirstName = "Дядя2",
                LastName = "Ненадо2",
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
                Contacts = new List<Contact>() { new Contact{ Value = "123456789", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false,

                },
                new Customer()
                {
                Id = 3,
                FirstName = "Дядя3",
                LastName = "Ненадо3",
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
                Contacts = new List<Contact>() { new Contact{ Value = "12345678910", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = true,

                }

            };

            var returnedCustomers = new List<Customer>
            {
                new Customer()
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
                    House = "1",
                    Apartament = 1,
                    IsDeleted = false,
                },
                Contacts = new List<Contact>() { new Contact{ Value = "12345678", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false,

                },
                new Customer()
                {
                Id = 2,
                FirstName = "Дядя2",
                LastName = "Ненадо2",
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
                Contacts = new List<Contact>() { new Contact{ Value = "123456789", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false,

                }
            };

            var expected = new List<CustomerModel>
            {
                new CustomerModel()
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
                Password = "admin",
                IsDeleted = false,

                },
                new CustomerModel()
                {
                Id = 2,
                FirstName = "Дядя2",
                LastName = "Ненадо2",
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
                Contacts = new List<ContactModel>() { new ContactModel { Value = "123456789", ContactType = ContactType.Phone } },
                Password = "admin",
                IsDeleted = false,

                }

            };

            yield return new object[] { customers, returnedCustomers, expected };

        }
    }
}
