using DogSitter.DAL.Repositories;
using Moq;
using AutoMapper;
using NUnit.Framework;
using DogSitter.DAL.Entity;
using DogService.BLL.Services;
using System.Collections.Generic;
using System;

namespace Tests;

public class ServiceTests
{
    private readonly Mock<IServiceRepository> _serviceRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public ServiceTests()
    {
        _serviceRepositoryMock = new Mock<IServiceRepository>();
        _mapperMock = new Mock<IMapper>();
    }

    [Test]
    public void GetServiceById_ServiceRepositoryReturnNotNullObject_NoExeption()
    {
        _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns(new Serviñe
        {
            Id = 1,
            Name = "Name1",
            Description = "Description1",
            Price = 1m,
            DurationHours = 1.0,
            IsDeleted = false
        });

        var sut = new ServiceService(_serviceRepositoryMock.Object, _mapperMock.Object);

        Assert.DoesNotThrow(() => sut.GetServiceById(1));
    }

    [Test]
    public void GetServiceById_ServiceRepositoryReturnNullObject_Exeption()
    {
        _serviceRepositoryMock.Setup(m => m.GetServiceById(1)).Returns((Serviñe)null);

        var sut = new ServiceService(_serviceRepositoryMock.Object, _mapperMock.Object);

        Assert.Throws<Exception>(() => sut.GetServiceById(1));
    }

    [Test]
    public void GetGetAllServices_ShouldReturnServices()
    {
        //arrange
        _serviceRepositoryMock.Setup(m => m.GetAllServices()).Returns(new List<Serviñe>
            {
                new Serviñe
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1m,
                    DurationHours = 1.0,
                    IsDeleted = false,
                }
            });

        var sut = new ServiceService(_serviceRepositoryMock.Object, _mapperMock.Object);

        //act
        var actual = sut.GetAllServices();

        //assert
        _serviceRepositoryMock.Verify(m => m.GetAllServices(), Times.Once);
        _serviceRepositoryMock.Verify(m => m.GetServiceById(It.IsAny<int>()), Times.Never);
        Assert.IsNotNull(actual);
        Assert.IsTrue(actual.Count > 0);
    }

    [Test]
    public void AddService_ShouldAddService()
    {
        _serviceRepositoryMock.Setup(m => m.AddService(new Serviñe
        {
            Id = 1,
            Name = "Name1",
            Description = "Description1",
            Price = 1m,
            DurationHours = 1.0,
            IsDeleted = false
        }));

    }
}
