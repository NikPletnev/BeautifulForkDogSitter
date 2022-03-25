using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


namespace DogSitter.BLL.Tests
{
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ISubwayStationRepository> _subwayStationRepositoryMock;
        private IMapper _mapper;
        private CustomerService _service;

        [SetUp]
        public void Setup()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _subwayStationRepositoryMock = new Mock<ISubwayStationRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new CustomerService(_customerRepositoryMock.Object, _mapper, _userRepositoryMock.Object, _subwayStationRepositoryMock.Object, new Mock<ILogger<EmailSendller>>().Object);
        }


        [TestCaseSource(typeof(GetCustomerByIdTestCaseSource))]
        public void GetCustomerByIdTestMustReturnCustomer(Customer customer, CustomerModel expected, int id)
        {
            //given
            _customerRepositoryMock.Setup(x => x.GetCustomerById(customer.Id)).Returns(customer);

            //when
            var actual = _service.GetCustomerById(customer.Id);

            //then
            Assert.AreEqual(actual, expected);
            _customerRepositoryMock.Verify(x => x.GetCustomerById(customer.Id), Times.Once);
        }

        [TestCaseSource(typeof(GetAllCustomersTestCaseSource))]
        public void GetAllCustomersTestMustReturnAllCustomers(List<Customer> customers, List<Customer> returnedCustomers, List<CustomerModel> expected)
        {
            //given
            _customerRepositoryMock.Setup(x => x.GetAllCustomers()).Returns(returnedCustomers);

            //when
            var actual = _service.GetAllCustomers();

            //then
            Assert.AreEqual(actual, expected);
            _customerRepositoryMock.Verify(x => x.GetAllCustomers(), Times.Once);
        }

        [TestCaseSource(typeof(GetCustomersForTestTestCaseSource))]
        public void AddCustomerMustAddCustomer(CustomerModel customer)
        {
            //given
            _customerRepositoryMock.Setup(x => x.AddCustomer(It.IsAny<Customer>()));
            //when
            _service.AddCustomer(customer);
            //then
            _customerRepositoryMock.Verify(x => x.AddCustomer(It.IsAny<Customer>()), Times.Once);
        }

        [TestCaseSource(typeof(GetCustomerForTestExeptionTestCaseSource))]
        public void AddCustomerMustThrowServieNotEnoughDataExeption(CustomerModel customer, Customer customerEntity)
        {
            //given
            _customerRepositoryMock.Setup(x => x.AddCustomer(It.IsAny<Customer>()));
            var expectedMessage = "There is not enough data to add new customer";
            //when

            //then
            ServiceNotEnoughDataExeption ex = Assert.Throws<ServiceNotEnoughDataExeption>(() =>
           _service.AddCustomer(customer));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(UpdateCustomerTestCaseSource))]
        public void UpdateCustomerMustUpdateCustomer(CustomerModel customerToUpdate, Customer customer)
        {

            _customerRepositoryMock.Setup(x => x.GetCustomerById(customer.Id)).Returns(customer);
            //when
            _service.UpdateCustomer(customer.Id, customerToUpdate);
            //then
            _customerRepositoryMock.Verify(y => y.UpdateCustomer(It.IsAny<Customer>(), It.IsAny<Customer>()), Times.Once);
            _customerRepositoryMock.Verify(x => x.GetCustomerById(customer.Id));
        }

        [TestCaseSource(typeof(GetCustomerForTestExeptionTestCaseSource))]
        public void UpdateCustomerMustThrowServieNotEnoughDataExeption(CustomerModel customer, Customer customerEntity)
        {
            //given
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(customerEntity, customerEntity));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(customerEntity.Id)).Returns(customerEntity);
            var expectedMessage = "There is not enough data to update customer";
            //when

            //then
            ServiceNotEnoughDataExeption ex = Assert.Throws<ServiceNotEnoughDataExeption>(() =>
            _service.UpdateCustomer(customer.Id, customer));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(UpdateCustomerTestCaseSource))]
        public void UpdateCustomerMustThrowEntityNotFoundException(CustomerModel customer, Customer customerEntity)
        {
            //given
            Customer nullCustomer = null;
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(customerEntity, customerEntity));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(customerEntity.Id)).Returns(nullCustomer);
            var expectedMessage = "Customer was not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.UpdateCustomer(customer.Id, customer));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetCustomerByIdTestCaseSource))]
        public void DeleteCustomerTestMustDeleteCustomer(Customer customer, CustomerModel expected, int id)
        {
            //gicen
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(id, true));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(id)).Returns(customer);
            _userRepositoryMock.Setup(x => x.GetUserById(customer.Id)).Returns(customer);
            //when
            _service.DeleteCustomerById(customer.Id, id);
            //then
            _customerRepositoryMock.Verify(x => x.UpdateCustomer(id, true), Times.Once);
            _customerRepositoryMock.Verify(x => x.GetCustomerById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetCustomerByIdTestCaseSource))]
        public void DeleteustomerTestMustThrowEntityNotFoundExeption(Customer customer, CustomerModel expected, int id)
        {
            //gicen
            Customer nullDog = null;
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(id, true));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(id)).Returns(nullDog);
            var expectedMessage = $"Customer was not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.DeleteCustomerById(customer.Id, id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetCustomerByIdTestCaseSource))]
        public void RestoreDogTestMustDeleteDog(Customer customer, CustomerModel expected, int id)
        {
            //gicen
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(id, false));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(id)).Returns(customer);
            //when
            _service.RestoreCustomer(id);
            //then
            _customerRepositoryMock.Verify(x => x.UpdateCustomer(id, false), Times.Once);
            _customerRepositoryMock.Verify(x => x.GetCustomerById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetCustomerByIdTestCaseSource))]
        public void RestoreAddressTestMustThrowEntityNotFoundExeption(Customer dog, CustomerModel expected, int id)
        {
            //gicen
            Customer nullCustomer = null;
            _customerRepositoryMock.Setup(x => x.UpdateCustomer(id, false));
            _customerRepositoryMock.Setup(x => x.GetCustomerById(id)).Returns(nullCustomer);
            var expectedMessage = $"Customer was not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.RestoreCustomer(id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }
}









