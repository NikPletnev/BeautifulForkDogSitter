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
    public class AddressServiceTests
    {
        private Mock<IAddressRepository> _addressRepositoryMock;
        private Mock<ICustomerRepository> _customerRepMock;
        private Mock<IUserRepository> _userRepMock;
        private IMapper _mapper;
        private AddressService _service;

        [SetUp]
        public void Setup()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _userRepMock = new Mock<IUserRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new AddressService(_mapper, _addressRepositoryMock.Object, _customerRepMock.Object, _userRepMock.Object);
        }

        [TestCaseSource(typeof(GetAllAddressTestCaseSource))]
        public void GetAllAddressTestMustReturnAllAddresess(List<Address> addresses, List<AddressModel> expected)
        {
            //given
            _addressRepositoryMock.Setup(x => x.GetAllAddress()).Returns(addresses);

            //when
            var actual = _service.GetAllAddresses();

            //then
            Assert.AreEqual(actual, expected);
            _addressRepositoryMock.Verify(x => x.GetAllAddress(), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void DeleteAddressTestMustDeleteAddress(Address address, AddressModel expected)
        {
            //gicen
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address.Id, true));
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(address);
            _userRepMock.Setup(x => x.GetUserById(address.Customer.Id)).Returns(address.Customer);
            //when
            _service.DeleteAddressById(address.Customer.Id, address.Id);
            //then
            _addressRepositoryMock.Verify(x => x.UpdateAddress(address.Id, true), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressById(address.Id), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void DeleteAddressTestMustThrowEntityNotFoundExeption(Address address, AddressModel expected)
        {
            //gicen
            Address nullAddress = null;
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address.Id, true));
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(nullAddress);
            _userRepMock.Setup(x => x.GetUserById(address.Customer.Id)).Returns(address.Customer);
            var expectedMessage = "Address not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.DeleteAddressById(address.Customer.Id, address.Id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }


        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void RestoreAddressTestMustDeleteAddress(Address address, AddressModel expected)
        {
            //gicen
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address.Id, false));
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(address);
            //when
            _service.RestoreAddress(address.Id);
            //then
            _addressRepositoryMock.Verify(x => x.UpdateAddress(address.Id, false), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressById(address.Id), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void RestoreAddressTestMustThrowEntityNotFoundExeption(Address address, AddressModel expected)
        {
            //gicen
            Address nullAddress = null;
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address.Id, false));
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(nullAddress);
            var expectedMessage = "Address not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.RestoreAddress(address.Id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }
}
