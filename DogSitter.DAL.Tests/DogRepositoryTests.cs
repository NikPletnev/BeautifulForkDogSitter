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
                .UseInMemoryDatabase("DogTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new DogRepository(_context);
        }

        [TestCaseSource(typeof(GetAllDogsByCustomerIdTestCaseSource))]
        public void GetAllDogsByCustomerIdTest(int id, List<Customer> customers, List<Dog> expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
            //when

            //then
            var actual = _rep.GetAllDogsByCustomerId(id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogListTestCaseSource))]
        public void GetAllDogsTestMustReturnAllDogs(List<Dog> dogs, List<Dog> expected)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();


            //when
            var actual = _rep.GetAllDogs();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogListWithNewDogTestCaseSource))]
        public void GetDogByIdTestMustReturnExpectedDog(List<Dog> dogs, Dog newDog, Dog expected)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();

            //when
            var actual = _rep.GetDogById(2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogListWithNewDogTestCaseSource))]
        public void AddDogTestMustAddExpectedDog(List<Dog> dogs, Dog newDog, Dog expected)
        {
            //given

            //when
            _rep.AddDog(newDog);

            var actual = _context.Dogs.FirstOrDefault(z => z.Id == newDog.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogListWithNewDogTestCaseSource))]
        public void DeleteDogTestMustChangeIsDeletedProp(List<Dog> dogs, Dog newDog, Dog expected)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();
            expected.IsDeleted = true;

            //when
            _rep.UpdateDog(2, true);
            var actual = _context.Dogs.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(DogListWithNewDogTestCaseSource))]
        public void UpdateDogsTestMustBeEqualExpectedExceptIsDelededProp(List<Dog> dogs, Dog newDog, Dog expected)
        {
            //given
            _context.Dogs.AddRange(dogs);
            _context.SaveChanges();
            expected.IsDeleted = true;
            //when
            _rep.UpdateDog(newDog);

            var actual = _context.Dogs.FirstOrDefault(z => z.Id == 2);

            //then

            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Weight, actual.Weight);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Breed, actual.Breed);
            Assert.AreNotEqual(expected.IsDeleted, actual.IsDeleted);
        }
    }
}

