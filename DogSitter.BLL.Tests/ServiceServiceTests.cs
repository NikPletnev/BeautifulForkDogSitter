using AutoMapper;
using DogService.BLL.Services;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.BLL.Tests.Services
{
    public class ServiceServiceTests
    {
        private readonly Mock<IServiceRepository> _serviceRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private ServiceService _service;

        public ServiceServiceTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [SetUp]
        public void SetUp()
        {
            _service = new ServiceService(_serviceRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public void GetServiceById_ServiceRepositoryReturnNotNullObject_NoExeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns(new Serviñe());

            Assert.DoesNotThrow(() => _service.GetServiceById(1));
        }

        [Test]
        public void GetServiceById_ServiceRepositoryReturnNullObject_Exeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns((Serviñe)null);

            Assert.Throws<Exception>(() => _service.GetServiceById(1));
        }

        [Test]
        public void GetGetAllServices_ShouldReturnServicesWithOrdersAndSitters()
        {
            _serviceRepositoryMock.Setup(m => m.GetAllServices()).Returns(new List<Serviñe>
            {
                new Serviñe
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    Orders = new List<Order>
                    {
                        new Order
                        {
                        Id = 1,
                        OrderDate = DateTime.Now,
                        Price = 1.1m,
                        Status = Status.create,
                        Mark = 1,
                        IsDeleted = false,
                        }
                    },
                    Sitters = new List<Sitter>
                    {
                        new Sitter
                        {
                            Id = 1,
                            Password = "Password1",
                            FirstName = "FirstName1",
                            LastName = "LastName1",
                            IsDeleted = false,
                            Information = "Information1",
                            Rating = 1.1
                        }
                    }
                }
            });

            _mapperMock.Setup(m => m.Map<List<ServiceModel>>(It.IsAny<List<Serviñe>>()))
                .Returns<List<Serviñe>>(x => x.Select(y => new ServiceModel
                {
                    Id = y.Id,
                    Name = y.Name,
                    Description = y.Description,
                    Price = y.Price,
                    DurationHours = y.DurationHours,
                    Orders = y.Orders.Select(o => new OrderModel()).ToList(),
                    Sitters = y.Sitters.Select(s => new SitterModel()).ToList()
                }).ToList());

            var actual = _service.GetAllServices();

            _serviceRepositoryMock.Verify(m => m.GetAllServices(), Times.Once);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Orders);
            Assert.IsNotNull(actual[0].Sitters);
        }

        [Test]
        public void AddService_ShouldAddService()
        {
            _serviceRepositoryMock.Setup(m => m.AddService(
                new Serviñe
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    IsDeleted = false,
                    Orders = new List<Order>
                    {
                        new Order
                        {
                        Id = 1,
                        OrderDate = DateTime.Now,
                        Price = 1.1m,
                        Status = Status.create,
                        Mark = 1,
                        IsDeleted = false,
                        }
                },
                    Sitters = new List<Sitter>
                    {
                        new Sitter
                        {
                            Id = 1,
                            Password = "Password1",
                            FirstName = "FirstName1",
                            LastName = "LastName1",
                            IsDeleted = false,
                            Information = "Information1",
                            Rating = 1.1
                        }
                    }
                }));

            _service.AddService(new ServiceModel());

            _serviceRepositoryMock.Verify(m => m.AddService(It.IsAny<Serviñe>()), Times.Once);
        }

        [Test]
        public void UpdateService_ServiceRepositoryReturnNotNullObject_NoExeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns(new Serviñe());

            Assert.DoesNotThrow(() => _service.UpdateService(1, new ServiceModel()));
        }

        [Test]
        public void UpdateService_ServiceRepositoryReturnNullObject_Exeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns((Serviñe)null);

            Assert.Throws<Exception>(() => _service.UpdateService(1, new ServiceModel()));
        }

        [Test]
        public void DeleteService_ServiceRepositoryReturnNotNullObject_NoExeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns(new Serviñe());

            Assert.DoesNotThrow(() => _service.DeleteService(1));
        }

        [Test]
        public void DeleteService_ServiceRepositoryReturnNullObject_Exeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns((Serviñe)null);

            Assert.Throws<Exception>(() => _service.DeleteService(1));
        }

        [Test]
        public void RestoreService_ServiceRepositoryReturnNotNullObject_NoExeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns(new Serviñe());

            Assert.DoesNotThrow(() => _service.RestoreService(1));
        }

        [Test]
        public void RestoreService_ServiceRepositoryReturnNullObject_Exeption()
        {
            _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns((Serviñe)null);

            Assert.Throws<Exception>(() => _service.RestoreService(1));
        }
    }
}
