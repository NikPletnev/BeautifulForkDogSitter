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

            var services = ServiceTestMock.GetServices();
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
        }

        [Test]
        public void AddServiceTest()
        {
            //given
            var expected = ServiceTestMock.GetService();

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
            var service = ServiceTestMock.GetService();
            _context.Services.Add(service);

            _context.SaveChanges();

            var updatedService = new Serviñe()
            {
                Id = service.Id,
                Name = "ChangeName",
                Description = "ChangeDescription",
                Price = 0m,
                DurationHours = 0.0,
                IsDeleted = service.IsDeleted,
                Orders = new List<Order>(),
                Sitter = new Sitter()
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Password = "Password1"
                }
            };

            //when
            _serviceRepository.UpdateService(service, updatedService);

            var actual = _context.Services.First(a => a.Id == service.Id);

            //then
            Assert.AreEqual(updatedService.Id, actual.Id);
            Assert.AreEqual(updatedService.Name, actual.Name);
            Assert.AreEqual(updatedService.Description, actual.Description);
            Assert.AreEqual(updatedService.Price, actual.Price);
            Assert.AreEqual(updatedService.DurationHours, actual.DurationHours);
            Assert.AreEqual(updatedService.IsDeleted, actual.IsDeleted);
            Assert.AreEqual(updatedService.Orders, actual.Orders);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateOrDeleteServiceTest(bool isDeleted)
        {
            //given
            var service = ServiceTestMock.GetService();

            //when
            _serviceRepository.UpdateOrDeleteService(service, isDeleted);

            //then
            Assert.AreEqual(service.IsDeleted, isDeleted);
        }

        //[TestCaseSource(typeof(GetAllServicesBySitterIdTestCaseSource))]
        //public void GetAllServicesBySitterIdTest(int id, Sitter sitter, List<Serviñe> expected)
        //{
        //    //given
        //    _context.Sitters.AddRange(sitter);
        //    _context.SaveChanges();

        //    //when
        //    var actual = _serviceRepository.GetAllServicesBySitterId(id);

        //    //then
        //    Assert.AreEqual(expected, actual);
        //}
    }
}