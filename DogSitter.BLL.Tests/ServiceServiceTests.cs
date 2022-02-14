using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace DogSitter.BLL.Tests
{
    public class ServiceServiceTests
    {
        private readonly Mock<IServiceRepository> _serviceRepositoryMock;
        private readonly IMapper _mapper;
        private ServiceService _service;
        private ServiceTestCaseSource _serviceMocks;

        public ServiceServiceTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
        }

        [SetUp]
        public void SetUp()
        {
            _service = new ServiceService(_serviceRepositoryMock.Object, _mapper);
            _serviceMocks = new ServiceTestCaseSource();
        }

        [Test]
        public void GetGetAllServices_ShouldReturnServices()
        {
            //given
            var expected = _serviceMocks.GetMockServices();
            _serviceRepositoryMock.Setup(m => m.GetAllServices()).Returns(expected);

            //when
            var actual = _service.GetAllServices();

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            _serviceRepositoryMock.Verify(m => m.GetAllServices(), Times.Once);
        }

        [Test]
        public void GetServiceByIdTest()
        {
            //given 
            var expected = _serviceMocks.GetMockService();
            _serviceRepositoryMock.Setup(m => m.GetServiceById(expected.Id)).Returns(expected);

            //when 
            var actual = _service.GetServiceById(3);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Description, expected.Description);
            Assert.AreEqual(actual.DurationHours, expected.DurationHours);
            Assert.AreEqual(actual.Price, expected.Price);
            Assert.That(actual.Orders.Count == 0);
            Assert.That(actual.Sitters.Count == 0);
            _serviceRepositoryMock.Verify(m => m.GetServiceById(expected.Id), Times.Once);
        }

        [Test]
        public void GetServiceByIdNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviñe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.GetServiceById(0));
        }

        [Test]
        public void AddServiceTest()
        {
            //given
            _serviceRepositoryMock.Setup(m => m.AddService(It.IsAny<Serviñe>()));

            //when 
            _service.AddService(It.IsAny<ServiceModel>());

            //then
            _serviceRepositoryMock.Verify(m => m.AddService(It.IsAny<Serviñe>()), Times.Once);
        }

        [Test]
        public void UpdateServiceTest()
        {
            //given
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviñe>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when
            _service.UpdateService(new ServiceModel());

            //then
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviñe>()), Times.Once());
            _serviceRepositoryMock.Verify(m => m.UpdateService(
                new Serviñe(), true), Times.Never());
        }

        [Test]
        public void UpdateServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviñe>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviñe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.UpdateService(new ServiceModel()));
        }

        [Test]
        public void DeleteServiceTest()
        {
            //given
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviñe>(), true));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when
            _service.DeleteService(new ServiceModel());

            //then
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviñe>()), Times.Never());
            _serviceRepositoryMock.Verify(m => m.UpdateService(
                It.IsAny<Serviñe>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void DeleteServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviñe>(), It.IsAny<bool>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviñe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteService(new ServiceModel()));
        }
        [Test]
        public void RestoreServiceTest()
        {
            //given
            _serviceRepositoryMock.Setup(m => m.RestoreService(It.IsAny<Serviñe>(), true));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when
            _service.RestoreService(new ServiceModel());

            //then
            _serviceRepositoryMock.Verify(m => m.RestoreService(It.IsAny<Serviñe>(), false), Times.Once());

        }

        [Test]
        public void RestoreServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviñe>(), It.IsAny<bool>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviñe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteService(new ServiceModel()));
        }
    }

}
