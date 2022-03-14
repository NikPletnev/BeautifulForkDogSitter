using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class DogListWithNewDogTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Dog> dogs = new List<Dog>() {
              new Dog()
              {
                  Id = 1,
                  Name = "TestDog1",
                  Age = 1,
                  Weight = 1,
                  Description = "TestDescription",
                  Breed = "TestBreed",
                  IsDeleted = false
              },
              new Dog()
              {
                  Id = 2,
                  Name = "TestDog2",
                  Age = 2,
                  Weight = 2,
                  Description = "TestDescription2",
                  Breed = "TestBreed2",
                  Customer = new Customer(){ FirstName = "FirstName1", LastName = "LastName1", Password = "Password1"},
                  IsDeleted = false
              },
              new Dog()
              {
                  Id = 3,
                  Name = "TestDog3",
                  Age = 3,
                  Weight = 3,
                  Description = "TestDescription3",
                  Breed = "TestBreed3",
                  IsDeleted = true
              }
            };

            var newDog = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2" }; ;

            var expected = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = false };

            yield return new object[] { dogs, newDog, expected };
        }
    }
}

