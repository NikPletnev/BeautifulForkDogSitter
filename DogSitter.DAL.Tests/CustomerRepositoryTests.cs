using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class CustomerRepositoryTests
    {
        private DogSitterContext _context;
        private CustomerRepository _customerRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("CustomerTest")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _customerRepository = new CustomerRepository(_context);
        }

        [TestCaseSource(typeof(CustomerChangeCustomerTestCaseSource))]
        public void ChangeCustomerAddressTestMustChangeAddress(Customer customer, Customer expected, Address address)
        {
            //given
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //when
            _customerRepository.ChangeCustomerAddress(customer, address);

            //then
            Assert.AreEqual(expected, customer);
        }
    }
}
