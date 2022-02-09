using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class ServiceServiceTests
    {
        private readonly Mock<IServiceRepository> _serviceRepositoryMock;
        private readonly IMapper _mapper;
        private ServiceService _service;

        public ServiceServiceTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
        }

        [SetUp]
        public void SetUp()
        {
            _service = new ServiceService(_serviceRepositoryMock.Object, _mapper);
        }

        [Test]
        public void GetServiceByIdTest()
        {
            //given 

            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
                IsDeleted = false
            });

            //when 

            var actual = _service.GetServiceById(It.IsAny<int>());

            //then

            Assert.IsNotNull(actual);
            Assert.DoesNotThrow(() => _service.GetServiceById(It.IsAny<int>()));
        }

        [Test]
        public void GetGetAllServices_ShouldReturnServices()
        {
            //given

            _serviceRepositoryMock.Setup(m => m.GetAllServices()).Returns(new List<Serviñe>
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
            });

            //when

            var actual = _service.GetAllServices();

            //then

            _serviceRepositoryMock.Verify(m => m.GetAllServices(), Times.Once);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
        }

        [Test]
        public void AddService_ShouldAddService()
        {
            //given

            _serviceRepositoryMock.Setup(m => m.AddService(
                new Serviñe
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    IsDeleted = false
                }));

            //when 

            _service.AddService(new ServiceModel
            {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                Price = 1m,
                DurationHours = 1.0,
            });

            //then

            Assert.Pass();
            _serviceRepositoryMock.Verify(m => m.AddService(It.IsAny<Serviñe>()), Times.Once);

        }

        [Test]
        public void UpdateServiceTest()
        {
            //given

            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when

            _service.UpdateService(It.IsAny<int>(), new ServiceModel());

            //then

            Assert.Pass();
            Assert.DoesNotThrow(() => _service.UpdateService(It.IsAny<int>(), new ServiceModel()));
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviñe>()), Times.Once());
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<int>(), false), Times.Never());
        }

        [Test]
        public void DeleteServiceTest()
        {
            //given

            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when

            _service.DeleteService(It.IsAny<int>());

            //then

            Assert.Pass();
            Assert.DoesNotThrow(() => _service.DeleteService(It.IsAny<int>()));
            _serviceRepositoryMock.Verify(m => m.DeleteService(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void RestoreServiceTest()
        {
            //given

            _serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns(new Serviñe());

            //when

            _service.RestoreService(It.IsAny<int>());

            //then

            Assert.Pass();
            Assert.DoesNotThrow(() => _service.RestoreService(It.IsAny<int>()));
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<int>(), false), Times.Once());
            _serviceRepositoryMock.Verify(m => m.UpdateService(It.IsAny<Serviñe>()), Times.Never());
        }

    }
}
