using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class DogRepositoryTests
    {
        private DogSitterContext _context;
        private DogRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("AdminTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new DogRepository(_context);
        }

        [TestCaseSource(typeof(DogTestCaseSource))]
        public void GetAllDogsTest(List<Dog> dogs)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();

            var expected = new List<Dog>() 
            {
                new Dog { Id = 1, Name = "TestDog1", Age = 1, Weight = 1, Description = "TestDescription", Breed = "TestBreed", IsDeleted = false},
                new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = false}
            };

            //when
            var actual = _rep.GetAllDogs();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogTestCaseSource))]
        public void GetDogByIdTest(List<Dog> dogs)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();

            var expected = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = false };

            //when
            var actual = _rep.GetDogById(2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddDogTest()
        {
            //given
            var dog = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2"};
            var expected = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = false };

            //when
            _rep.AddDog(dog);

            var actual = _context.Dogs.FirstOrDefault(z => z.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogTestCaseSource))]
        public void DeleteDogTest(List<Dog> dogs)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();

            var expected = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = true };

            //when
            _rep.UpdateDog(2, true);
            var actual = _context.Dogs.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogTestCaseSource))]
        public void UpdateDogsTest(List<Dog> dogs)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();

            var newDog = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2"};

            var expected = new Dog { Id = 2, Name = "TestDog2", Age = 2, Weight = 2, Description = "TestDescription2", Breed = "TestBreed2", IsDeleted = false };

            //when
            _rep.UpdateDog(newDog);

            var actual = _context.Dogs.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
