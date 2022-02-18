using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class AddressServiceTests
    {
        private readonly Mock<IAddressRepository> _addressRepositoryMock;
        private readonly Mock<ICustomerRepository> _customerRepMock;
        private readonly IMapper _mapper;
        private readonly AddressService _service;

        public AddressServiceTests()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new AddressService(_mapper, _addressRepositoryMock.Object, _customerRepMock.Object);
        }

        [TestCaseSource(typeof(GetAddressByCustomerIdTestCaseSource))]
        public void GetAddressByCustomerIdTest(int id, Customer customer, List<Address> addresses)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id)).Returns(customer);
            _addressRepositoryMock.Setup(x => x.GetAddressByCustomerId(customer)).Returns(addresses);
            //when
            _service.GetAddressByCustomerId(id);
            //then
            _customerRepMock.Verify(x => x.GetCustomerById(id), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressByCustomerId(customer), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByCustomerIdTestCaseSource))]
        public void GetAddressByCustomerIdTest_WhenCustomerNotFound_ShouldThrowEntityNotFoundException(int id, Customer customer, List<Address> addresses)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id));
            _addressRepositoryMock.Setup(x => x.GetAddressByCustomerId(customer)).Returns(addresses);
            //when

            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetAddressByCustomerId(id));
            _customerRepMock.Verify(x => x.GetCustomerById(id), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressByCustomerId(customer), Times.Never);
        }


    }
}
