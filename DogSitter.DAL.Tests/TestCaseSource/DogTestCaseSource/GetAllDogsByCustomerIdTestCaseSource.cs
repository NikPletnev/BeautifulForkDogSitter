using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllDogsByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;

            List<Customer> customers = new List<Customer>() {
              new Customer()
              {
                  FirstName = "Иван",
                  LastName = "Иванов",
                  Password = "VANYA1234" ,
                  Dogs = new List<Dog>()
                  {
                      new Dog()
                      {
                          Name = "Собака-Бабака",
                          Age = 33,
                          Breed = "Ротвейлер",
                          Weight = 51,
                          Description = "гав гав",
                          IsDeleted = false
                      }
                  },
                  IsDeleted = false
              },
              new Customer()
              {
                  FirstName = "Иван2",
                  LastName = "Иванов2",
                  Password = "2VANYA1234",
                  Dogs = new List<Dog>()
                  {
                      new Dog()
                      {
                          Id =  2,
                          Name = "Белка",
                          Age = 1,
                          Breed = "Лабрадор",
                          Weight = 31.8,
                          Description = "ййй",
                          IsDeleted = false
                      }
                  },
                  IsDeleted = false
              },
              new Customer()
              {
                  FirstName = "Иван2",
                  LastName = "Иванов2",
                  Password = "2VANYA1234",
                  IsDeleted = true }
            };

            List<Dog> expected = new List<Dog>()
            {
                new Dog()
                {
                    Id =  2,
                    Name = "Белка",
                    Age = 1,
                    Breed = "Лабрадор",
                    Weight = 31.8,
                    Description = "ййй",
                    IsDeleted = false
                }
            };

            yield return new object[] { id, customers, expected };

            int id2 = 3;

            List<Dog> expected2 = new List<Dog>() { };

            yield return new object[] { id2, customers, expected2 };
        }
    }
}