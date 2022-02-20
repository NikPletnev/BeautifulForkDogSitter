using DogSitter.BLL.Models;
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
    public class GetDogForTestExeptionTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var dogWithNoName =  new DogModel
            {
                Name = "",
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

            var dogWithNoAge = new DogModel
            {
                Name = "TestDog",
                Age = 0,
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

            var dogWithNoWeight = new DogModel
            {
                Name = "TestDog",
                Age = 1,
                Weight = 0,
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

            var dogWithNoBreed = new DogModel
            {
                Name = "TestDog",
                Age = 0,
                Weight = 1,
                Description = "TestDescr",
                Breed = "",
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

            var dogEntity = new Dog
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


            yield return new object[] { dogWithNoName, dogEntity };
            yield return new object[] { dogWithNoAge, dogEntity };
            yield return new object[] { dogWithNoWeight, dogEntity };
            yield return new object[] { dogWithNoBreed, dogEntity };

        }
    }
}
