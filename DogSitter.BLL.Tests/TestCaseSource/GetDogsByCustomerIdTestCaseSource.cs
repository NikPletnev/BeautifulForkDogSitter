using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class GetDogsByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Customer customer =
              new Customer()
              {
                  Id = 1,
                  FirstName = "Иван2",
                  LastName = "Иванов2",
                  Password = "2VANYA1234",
                  Dogs = new List<Dog>()
                  {
                      new Dog()
                      {
                          Id =  1,
                          Name = "Белка",
                          Age = 1,
                          Breed = "Лабрадор",
                          Weight = 31.8,
                          Description = "ййй",
                          IsDeleted = false
                      }
                  },
                  IsDeleted = false
              };


            List<Dog> expected = new List<Dog>()
            {
                new Dog()
                {
                    Id =  1,
                    Name = "Белка",
                    Age = 1,
                    Breed = "Лабрадор",
                    Weight = 31.8,
                    Description = "ййй",
                    IsDeleted = false
                }
            };

            yield return new object[] { id, customer, expected };

            int id2 = 3;

            Customer customer2 = new Customer()
            {
                Id = 3,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                IsDeleted = true
            };

            List<Dog> expected2 = new List<Dog>() { };

            yield return new object[] { id2, customer2, expected2 };
        }
    }
}