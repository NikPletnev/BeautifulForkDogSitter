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
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class ServiceServiceTests
    {
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private Mock<ISitterRepository> _sitterRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private IMapper _mapper;
        private ServiceService _service;
        private ServiceTestMock _serviceMocks;

        [SetUp]
        public void SetUp()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new ServiceService(_serviceRepositoryMock.Object, _sitterRepositoryMock.Object,
                _userRepositoryMock.Object, _mapper);
            _serviceMocks = new ServiceTestMock();
        }

        [Test]
        public void GetAllServicesTest()
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
            _serviceRepositoryMock.Verify(m => m.GetServiceById(expected.Id), Times.Once);
        }

        [Test]
        public void GetServiceByIdNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviсe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.GetServiceById(0));
        }

        [TestCase(77)]
        public void AddServiceTest(int expected)
        {
            //given
            var service = _serviceMocks.GetMockService();

            _serviceRepositoryMock.Setup(m => m.AddService(service)).Returns(expected);
            _userRepositoryMock.Setup(x => x.GetUserById(service.Sitter.Id)).Returns(service.Sitter);

            //when 
            var actual = _service.AddService(service.Sitter.Id, _mapper.Map<ServiceModel>(service));

            //then
            _serviceRepositoryMock.Verify(m => m.AddService(It.IsAny<Serviсe>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void UpdateServiceTest()
        {
            //given
            var service = _serviceMocks.GetMockService();
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviсe>(), It.IsAny<Serviсe>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(service);
            _userRepositoryMock.Setup(x => x.GetUserById(service.Sitter.Id)).Returns(service.Sitter);

            //when
            _service.UpdateService(service.Sitter.Id, service.Id, It.IsAny<ServiceModel>());

            //then
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviсe>(), It.IsAny<Serviсe>()), Times.Once());
            _serviceRepositoryMock.Verify(m => m.UpdateOrDeleteService(
                new Serviсe(), It.IsAny<bool>()), Times.Never());
        }

        [Test]
        public void UpdateServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateService(It.IsAny<Serviсe>(), It.IsAny<Serviсe>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviсe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.UpdateService(It.IsAny<int>(), It.IsAny<int>(), new ServiceModel()));
        }

        [Test]
        public void DeleteServiceTest()
        {
            //given
            var service = _serviceMocks.GetMockService();
            _serviceRepositoryMock.Setup(m => m.UpdateOrDeleteService(service, true));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(service);
            _userRepositoryMock.Setup(x => x.GetUserById(service.Sitter.Id)).Returns(service.Sitter);

            //when
            _service.DeleteService(service.Sitter.Id, service.Id);

            //then
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviсe>(), It.IsAny<Serviсe>()), Times.Never());
            _serviceRepositoryMock.Verify(m => m.UpdateOrDeleteService(
                It.IsAny<Serviсe>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void DeleteServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateOrDeleteService(It.IsAny<Serviсe>(), It.IsAny<bool>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviсe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteService(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void RestoreServiceTest()
        {
            //given
            _serviceRepositoryMock.Setup(m => m.UpdateOrDeleteService(It.IsAny<Serviсe>(), true));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviсe());

            //when
            _service.RestoreService(It.IsAny<int>());

            //then
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviсe>(), It.IsAny<Serviсe>()), Times.Never());
            _serviceRepositoryMock.Verify(m => m.UpdateOrDeleteService(
                It.IsAny<Serviсe>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void RestoreServiceNegativeTest()
        {
            _serviceRepositoryMock.Setup(m => m.UpdateOrDeleteService(It.IsAny<Serviсe>(), It.IsAny<bool>()));
            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviсe)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteService(It.IsAny<int>(), It.IsAny<int>()));
        }

        [TestCaseSource(typeof(GetAllServicesBySitterIdTestCaseSource))]
        public void GetAllServicesBySitterIdTest(int id, Sitter sitter, List<Serviсe> service)
        {
            //given
            _sitterRepositoryMock.Setup(m => m.GetById(id)).Returns(sitter);
            _serviceRepositoryMock.Setup(m => m.GetAllServicesBySitterId(id)).Returns(service);
            _userRepositoryMock.Setup(x => x.GetUserById(sitter.Id)).Returns(sitter);

            //when
            var actual = _service.GetAllServicesBySitterId(sitter.Id, id);

            //then
            _sitterRepositoryMock.Verify(m => m.GetById(id), Times.Once);
            _serviceRepositoryMock.Verify(m => m.GetAllServicesBySitterId(id), Times.Once);
        }

        [Test]
        public void GetAllServicesBySitterIdNegativeTest()
        {
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Sitter)null);

            Assert.Throws<EntityNotFoundException>(() => _service.GetAllServicesBySitterId(It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
