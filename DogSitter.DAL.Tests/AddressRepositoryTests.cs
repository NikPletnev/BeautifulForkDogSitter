using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class AddressRepositoryTests
    {
        private DogSitterContext _dbContext;
        private AddressRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _dbContext = new DogSitterContext(options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _repository = new AddressRepository(_dbContext);
        }

        [TestCaseSource(typeof(GetTestAddressTestCaseSource))]
        public void GetAddressByIdTestMustReturnAddress(Address testAddress)
        {
            //given

            _dbContext.Addresses.Add(testAddress);
            _dbContext.SaveChanges();
            var addressId = testAddress.Id;

            //when

            var receivedAddress = _repository.GetAddressById(addressId);

            //then
            Assert.IsNotNull(receivedAddress);
            Assert.AreEqual(testAddress, receivedAddress);

        }

        [TestCaseSource(typeof(GetTestAddressesTestCaseSource))]
        public void GetAllAddressTestMustReturnAllAddresses(List<Address> address)
        {
            //given
            foreach (var testAddress in address)
            {
                _dbContext.Addresses.Add(testAddress);
            }
            _dbContext.SaveChanges();
            var expectedAddress = _dbContext.Addresses.Where(d => !d.IsDeleted).ToList();

            //when

            var receivedAddresses = _repository.GetAllAddress();

            //then
            Assert.IsNotNull(receivedAddresses);
            Assert.AreEqual(expectedAddress, receivedAddresses);
        }

        [TestCaseSource(typeof(GetTestAddressTestCaseSource))]
        public void AddAddressTestMustAddAddressInDB(Address address)
        {
            //given


            //when

            _repository.AddAddress(address);

            //then
            Assert.IsNotNull(_dbContext.Addresses);
            Assert.AreEqual(address, _dbContext.Addresses.FirstOrDefault(o => o.Id == address.Id));
        }

        [TestCaseSource(typeof(GetTestAddressTestCaseSource))]
        public void UpdateAddressTestMustUpdateAddressInDB(Address address)
        {
            //given

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();
            var addressToUpdate = new Address()
            {
                Id = address.Id,
                Name = "TestNamUpdate",
                City = "TestCityUpdate",
                Street = "TestStreetUpdate",
                House = "3",
                Apartament = 4,
                IsDeleted = true
            };

            //when

            _repository.UpdateAddress(addressToUpdate);
            var result = _dbContext.Addresses.FirstOrDefault(o => o.Id == address.Id);

            //then
            Assert.AreEqual(address, result);
            Assert.AreEqual(address.Name, result.Name);
            Assert.AreEqual(address.City, result.City);
            Assert.AreEqual(address.Street, result.Street);
            Assert.AreEqual(address.House, result.House);
            Assert.AreEqual(address.Apartament, result.Apartament);
            Assert.AreEqual(address.IsDeleted, result.IsDeleted);
        }

        [TestCaseSource(typeof(GetTestAddressTestCaseSource))]
        public void UpdateAddressForDeleteTestMustChangeIsDeletedProp(Address address)
        {
            //given

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            //when

            _repository.UpdateAddress(address.Id, true);

            //then
            Assert.IsTrue(_dbContext.Addresses.FirstOrDefault(o => o.Id == address.Id).IsDeleted);
        }

        [TestCaseSource(typeof(GetAddressByCustomerIdTestCaseSource))]
        public void GetAddressByCustomerIdTest(Customer customer, Address expected)
        {
            //given
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            //when
            var actual = _repository.GetAddressByCustomerId(customer);

            //then
            Assert.AreEqual(expected, actual);
        }
    }

}
