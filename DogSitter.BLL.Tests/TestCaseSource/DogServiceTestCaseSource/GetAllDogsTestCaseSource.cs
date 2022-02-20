using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllDogsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
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
                        Password = "123456",
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
                        Password = "123456",
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
                    Customer = new CustomerModel
                    {
                        FirstName = "Иван",
                        LastName = "Иванов",
                        Password = "123456",
                        Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                        IsDeleted = false
                    }
                },
                new DogModel
                {
                    Name = "TestDog2",
                    Age = 2,
                    Weight = 2,
                    Description = "TestDescr2",
                    Breed = "TetsBreed2",
                    IsDeleted = false,
                    Customer = new CustomerModel
                    {
                        FirstName = "Иван",
                        LastName = "Иванов",
                        Password = "123456",
                        Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                        IsDeleted = false
                    }
                }

            };


            yield return new object[] { dogs, expected };

        }
    }
}

