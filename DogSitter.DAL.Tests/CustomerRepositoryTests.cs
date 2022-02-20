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

        [TestCaseSource(typeof(CustomerLoginTestCaseSource))]
        public void LoginTest(List<Customer> customers, Contact contact, string pass, Customer expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
            var foundCustomer = _context.Customers.FirstOrDefault(c => c.Id == 1);
            contact.User = foundCustomer;
            _context.SaveChanges();

            //when
            var actual = _customerRepository.Login(contact, pass);

            //then
            Assert.AreEqual(expected, actual);
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
