using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace DogSitter.BLL.Tests
{
    public class AddressServiceTests
    {
        private Mock<IAddressRepository> _addressRepositoryMock;
        private Mock<ICustomerRepository> _customerRepMock;
        private IMapper _mapper;
        private AddressService _service;

        [SetUp]
        public void Setup()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new AddressService(_mapper, _addressRepositoryMock.Object, _customerRepMock.Object);
        }

        [TestCaseSource(typeof(GetAddressByCustomerIdTestCaseSource))]
        public void GetAddressByCustomerIdTest(int id, Customer customer, Address address)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id)).Returns(customer);
            _addressRepositoryMock.Setup(x => x.GetAddressByCustomerId(customer)).Returns(address);
            //when
            _service.GetAddressByCustomerId(id);
            //then
            _customerRepMock.Verify(x => x.GetCustomerById(id), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressByCustomerId(customer), Times.Once);
        }

        [TestCaseSource(typeof(GetAddressByCustomerIdTestCaseSource))]
        public void GetAddressByCustomerIdTest_WhenCustomerNotFound_ShouldThrowEntityNotFoundException(int id, Customer customer, Address address)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id));
            _addressRepositoryMock.Setup(x => x.GetAddressByCustomerId(customer)).Returns(address);
            //when

            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetAddressByCustomerId(id));
            _customerRepMock.Verify(x => x.GetCustomerById(id), Times.Once);
            _addressRepositoryMock.Verify(x => x.GetAddressByCustomerId(customer), Times.Never);
        }


    }
}
