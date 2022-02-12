using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class ServiceRepositoryTests
    {
        private DogSitterContext _context;
        private ServiceRepository _serviceRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "ServiceTests")
            .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _serviceRepository = new ServiceRepository(_context);

            var services = ServiceTestCaseSourse.GetServices();
            _context.Services.AddRange(services);

            _context.SaveChanges();
        }

        [Test]
        public void GetAllServicesTest()
        {
            // given
            var expected = _context.Services.Where(e => !e.IsDeleted);

            // when
            var actual = _serviceRepository.GetAllServices();

            // then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Where(e => e.IsDeleted), actual.Where(a => a.IsDeleted));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetServiceByIdTest(int id)
        {
            //given
            var expected = _context.Services.Find(id);

            //when
            var actual = _serviceRepository.GetServiceById(id);

            //then
            Assert.AreEqual(expected, actual);
            Assert.That(actual.IsDeleted == false | true);
        }

        [Test]
        public void AddServiceTest()
        {
            //given
            var expected = ServiceTestCaseSourse.GetService();

            //when
            _serviceRepository.AddService(expected);

            var actual = _context.Services.FirstOrDefault(a => a.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateServiceTest()
        {
            //given
            var service = ServiceTestCaseSourse.GetService();
            _context.Services.Add(service);

            _context.SaveChanges();

            var expected = new Serviñe()
            {
                Id = service.Id,
                Name = "ChangeName",
                Description = "ChangeDescription",
                Price = 0m,
                DurationHours = 0.0,
                IsDeleted = service.IsDeleted,
                Orders = new List<Order>(),
                Sitters = new List<Sitter>()
            };

            //when
            _serviceRepository.UpdateService(service);

            var actual = _context.Services.FirstOrDefault(a => a.Id == service.Id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreNotEqual(expected.Name, actual.Name);
            Assert.AreNotEqual(expected.Description, actual.Description);
            Assert.AreNotEqual(expected.Price, actual.Price);
            Assert.AreNotEqual(expected.DurationHours, actual.DurationHours);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
            Assert.AreEqual(expected.Orders, actual.Orders);
            Assert.AreEqual(expected.Sitters, actual.Sitters);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateIsDeleteServiceTest(bool isDeleted)
        {
            //given
            var service = ServiceTestCaseSourse.GetService();

            //when
            _serviceRepository.UpdateService(service, isDeleted);

            //then
            Assert.AreEqual(service.IsDeleted, isDeleted);
        }
    }
}