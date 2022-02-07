using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class ServiceRepositoryTests
    {
        private DogSitterContext _dbContext;
        private ServiceRepository _serviceRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "ServiceTests")
            .Options;

            _dbContext = new DogSitterContext(options);

            _dbContext.Database.EnsureCreated();
            _dbContext.Database.EnsureDeleted();

            _serviceRepository = new ServiceRepository(_dbContext);
        }

        [Test]
        public void GetAllServicesTest()
        {
            // given
            var services = new List<Serviñe>
            {
                new Serviñe
                {
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    IsDeleted = false
            }};

            _dbContext.Services.AddRange(services);

            _dbContext.SaveChanges();

            var expected = new List<Serviñe>
            {
                new Serviñe
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    IsDeleted = false
                }
            };

            // when
            var actual = _serviceRepository.GetAllServices();

            // then
            Assert.IsTrue(expected.SequenceEqual(actual));
            CollectionAssert.AreEqual(expected, actual);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetServiceByIdTest()
        {
            //given
            var service = new Serviñe
            {
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            _dbContext.Services.Add(service);

            _dbContext.SaveChanges();

            var expected = new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            //when
            var actual = _serviceRepository.GetServiceById(1);

            //then
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AddServiceTest()
        {
            //given
            var service = new Serviñe
            {
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            var expected = new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            //when
            _serviceRepository.AddService(service);

            var actual = _dbContext.Services.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void DeleteServiceTest()
        {
            //given
            var service = new Serviñe
            {
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();

            var expected = new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = true
            };

            //when
            _serviceRepository.DeleteService(1);

            var actual = _dbContext.Services.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.IsNull(actual);
        }

        [Test]
        public void UpdateServiceTest()
        {
            //given
            var service = new Serviñe
            {
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();

            var expected = new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "DescriptionChange",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            //when
            _serviceRepository.UpdateService(service);

            var actual = _dbContext.Services.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreNotEqual(actual, expected);
        }

        [Test]
        public void UpdateServiceTest_IdIsDeleted()
        {
            //given
            var service = new Serviñe
            {
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            };

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();

            var expected = new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "DescriptionChange",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = true
            };

            //when
            _serviceRepository.UpdateService(1, true);

            var actual = _dbContext.Services.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreNotEqual(actual, expected);
        }
    }
}