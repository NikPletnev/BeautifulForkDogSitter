using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var actual = _rep.GetAllDogsByCustomerId(id);
            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
