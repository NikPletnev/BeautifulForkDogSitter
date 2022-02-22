using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;


namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllDogsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var password = PasswordHash.HashPassword("123456");

            CustomerModel customer = new CustomerModel
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = password,
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            var dogs = new List<Dog>
            {
                new Dog
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
                        Password = password,
                        Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                        IsDeleted = false
                    }
                },
                new Dog
                {
                    Id = 2,
                    Name = "TestDog2",
                    Age = 2,
                    Weight = 2,
                    Description = "TestDescr2",
                    Breed = "TetsBreed2",
                    IsDeleted = false,
                    Customer = new Customer
                    {
                        FirstName = "Иван",
                        LastName = "Иванов",
                        Password = password,
                        Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                        IsDeleted = false
                    }
                }

            };

            var expected = new List<DogModel>
            {
                new DogModel
                {
                    Name = "TestDog",
                    Age = 1,
                    Weight = 1,
                    Description = "TestDescr",
                    Breed = "TetsBreed",
                    IsDeleted = false,
                    Customer = customer
                },
                new DogModel
                {
                    Name = "TestDog2",
                    Age = 2,
                    Weight = 2,
                    Description = "TestDescr2",
                    Breed = "TetsBreed2",
                    IsDeleted = false,
                    Customer = customer
                }

            };

            yield return new object[] { dogs, expected };

        }
    }
}

