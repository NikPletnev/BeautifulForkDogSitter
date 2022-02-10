using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections;
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

            //when

            var receivedAddresses = _repository.GetAllAddress();

            //then
            Assert.IsNotNull(receivedAddresses);
            Assert.AreEqual(address, receivedAddresses);
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

            //when

            _repository.UpdateAddress(address);

            //then
            Assert.AreEqual(address, _dbContext.Addresses.FirstOrDefault(o => o.Id == address.Id));
        }

        [TestCaseSource(typeof(GetTestAddressTestCaseSource))]
        public void DeleteAddressByIdTestMustDeleteAddressDromDB(Address address)
        {
            //given

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            //when

            _repository.DeleteAddressById(address.Id);

            //then
            Assert.IsNull(_dbContext.Addresses.FirstOrDefault(o => o.Id == address.Id));
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

    }
    class GetTestAddressTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Address
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false,
            };
            yield return new Address
            {
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = 2,
                Apartament = 2,
                IsDeleted = false,
            };
            yield return new Address
            {
                Id = 3,
                Name = "TestName3",
                City = "TestCity3",
                Street = "TestStreet3",
                House = 3,
                Apartament = 3,
                IsDeleted = false,
            }; 
        }
    }
    class GetTestAddressesTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new List<Address>
            {
                new Address{
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false
                },
                new Address{
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = 2,
                Apartament = 2,
                IsDeleted = false
                }

            };
            yield return new List<Address>
            {
                new Address{
                Id = 3,
                Name = "TestName3",
                City = "TestCity3",
                Street = "TestStreet3",
                House = 3,
                Apartament = 3,
                IsDeleted = false
                },
                new Address{
                Id = 4,
                Name = "TestName4",
                City = "TestCity4",
                Street = "TestStreet4",
                House = 4,
                Apartament = 4,
                IsDeleted = false
                }

            };
        }
    }
}
