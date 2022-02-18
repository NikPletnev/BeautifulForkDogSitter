﻿using AutoMapper;
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
        private readonly Mock<IAddressRepository> _addressRepositoryMock;
        private readonly IMapper _mapper;
        private readonly IAddressService _service;

        public AddressServiceTests()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new AddressService(_addressRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void GetAddressByIdTestMustReturnAddress(Address address, AddressModel expected)
        {
            //given
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(address);

            //when
            var actual = _service.GetAddressById(address.Id);

            //then
            Assert.AreEqual(actual, expected);
            _addressRepositoryMock.Verify(x => x.GetAddressById(address.Id), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void GetAddressByIdTestWhenAddressNotFoundMustthrowExeption(Address address, AddressModel expected)
        {
            //given

            Address nullAddress = null;
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(nullAddress);
            var expectedMessage = "Address not found";
            //when


            //then

            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.GetAddressById(address.Id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
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

        [TestCaseSource(typeof(GetAddressForTestTestCaseSource))]
        public void AddAddressMustAddAddress(AddressModel address)
        {
            //given
            _addressRepositoryMock.Setup(x => x.AddAddress(It.IsAny<Address>())).Verifiable();
            //when
            _service.AddAddress(address);
            //then
            _addressRepositoryMock.Verify(x => x.AddAddress(It.IsAny<Address>()));
        }


        [TestCaseSource(typeof(GetAddressForTestExeptionTestCaseSource))]
        public void AddAddressMustThrowServieNotEnoughDataExeption(AddressModel address, Address addressEntity)
        {
            //given
            _addressRepositoryMock.Setup(x => x.AddAddress(It.IsAny<Address>())).Verifiable();
            var expectedMessage = "There is not enough data to create new address";
            //when

            //then
            ServiceNotEnoughDataExeption ex = Assert.Throws<ServiceNotEnoughDataExeption>(() =>
           _service.AddAddress(address));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(UpdateAddressTestCaseSource))]
        public void UpdateAddressMustUpdateAddress(Address address, AddressModel addressToUpdate)
        {
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address)).Verifiable();
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(address).Verifiable();
            //when
            _service.UpdateAddress(addressToUpdate);
            //then
            _addressRepositoryMock.Verify(x => x.GetAddressById(address.Id));
            _addressRepositoryMock.Verify(x => x.UpdateAddress(address), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressForTestExeptionTestCaseSource))]
        public void UpdateAddressMustThrowServieNotEnoughDataExeption(AddressModel address, Address addressEntity)
        {
            //given
            _addressRepositoryMock.Setup(x => x.UpdateAddress(addressEntity)).Verifiable();
            _addressRepositoryMock.Setup(x => x.GetAddressById(addressEntity.Id)).Returns(addressEntity).Verifiable();
            var expectedMessage = "There is not enough data to update address";
            //when

            //then
            ServiceNotEnoughDataExeption ex = Assert.Throws<ServiceNotEnoughDataExeption>(() =>
            _service.UpdateAddress(address));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }


        [TestCaseSource(typeof(UpdateAddressTestCaseSource))]
        public void UpdateAddressMustThrowEntityNotFoundException(Address addressEntity, AddressModel address)
        {
            //given
            Address nullAddress = null;
            _addressRepositoryMock.Setup(x => x.UpdateAddress(addressEntity)).Verifiable();
            _addressRepositoryMock.Setup(x => x.GetAddressById(addressEntity.Id)).Returns(nullAddress).Verifiable();
            var expectedMessage = "Address not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.UpdateAddress(address));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetAddressByIdTestCaseSource))]
        public void DeleteAddressTestMustDeleteAddress(Address address, AddressModel expected)
        {
            //gicen
            _addressRepositoryMock.Setup(x => x.UpdateAddress(address.Id, true));
            _addressRepositoryMock.Setup(x => x.GetAddressById(address.Id)).Returns(address);
            //when
            _service.DeleteAddressById(address.Id);
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
            var expectedMessage = "Address not found";
            //when
            
            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.DeleteAddressById(address.Id));
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
            _service.DeleteAddressById(address.Id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }
}
