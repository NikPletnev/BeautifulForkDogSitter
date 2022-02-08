using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DogSitter.DAL.Tests
{
    public class AddressServiceTests
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

        [Test]
        public void GetAddressById() 
        {
            //given

            var testAddress = GetTestAddress();
            _dbContext.Addresses.Add(testAddress);
            _dbContext.SaveChanges();
            int AddressId = testAddress.Id;

            //when

            var receivedAddress = _repository.GetAddressById(AddressId);

            //then
            Assert.IsNotNull(receivedAddress);
            
        }


        public Address GetTestAddress()
        {
            return new Address()
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false,
            };
        }
    }
}
