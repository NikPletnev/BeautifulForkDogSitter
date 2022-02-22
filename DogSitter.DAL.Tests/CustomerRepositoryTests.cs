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
        private CustomerRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new DogSitterContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new CustomerRepository(_context);
        }

        [TestCaseSource(typeof(CustomerTestCaseSource))]
        public void GetAllCustomersTestMustReturnAllCustomers(List<Customer> customers, List<Customer> expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();


            //when
            var actual = _repository.GetAllCustomers();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CustomerWithNewCustomerTestCaseSource))]
        public void GetCustomerByIdTestMustReturnExpectedCustomer(List<Customer> customers, Customer newCustomer, Customer expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();

            //when
            var actual = _repository.GetCustomerById(2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CustomerWithNewCustomerTestCaseSource))]
        public void AddCustomerTestMustAddExpectedCustomer(List<Customer> customers, Customer newCustomer, Customer expected)
        {
            //given

            //when
            _repository.AddCustomer(newCustomer);

            var actual = _context.Customers.FirstOrDefault(z => z.Id == newCustomer.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CustomerWithNewCustomerTestCaseSource))]
        public void DeleteCustomerTestMustChangeIsDeletedProp(List<Customer> customers, Customer newCustomer, Customer expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
            expected.IsDeleted = true;

            //when
            _repository.UpdateCustomer(2, true);
            var actual = _context.Customers.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CustomerWithNewCustomerTestCaseSource))]
        public void UpdateCustomerTestMustBeEqualExpectedExceptIsDelededProp(List<Customer> customers, Customer newCustomer, Customer expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
            expected.IsDeleted = true;
            var entity = _context.Customers.FirstOrDefault(z => z.Id == 2);

            //when
            _repository.UpdateCustomer(newCustomer, entity);

            var actual = _context.Customers.FirstOrDefault(z => z.Id == 2);

            //then

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreNotEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [TestCaseSource(typeof(CustomerChangeCustomerTestCaseSource))]
        public void ChangeCustomerAddressTestMustChangeAddress(Customer customer, Customer expected, Address address)
        {
            //given
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //when
            _repository.ChangeCustomerAddress(customer, address);

            //then
            Assert.AreEqual(expected, customer);
        }

    }
}
