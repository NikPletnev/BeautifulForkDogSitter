using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class DogServiceTests
    {
        private Mock<IDogRepository> _dogRepositoryMock;
        private Mock<ICustomerRepository> _customerRepository;
        private IMapper _mapper;
        private DogService _service;

        [SetUp]
        public void Setup()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new DogService(_mapper, _dogRepositoryMock.Object, _customerRepository.Object);
        }


        [TestCaseSource(typeof(GetDogsByCustomerIdTestCaseSource))]
        public void GetDogsByCustomerIdTest(int id, Customer customer, List<Dog> dogs)
        {
            //given
            _customerRepository.Setup(x => x.GetCustomerById(id)).Returns(customer).Verifiable();
            _dogRepositoryMock.Setup(x => x.GetAllDogsByCustomerId(id)).Returns(dogs).Verifiable();
            //when
            var actual = _service.GetDogsByCustomerId(id);
            //then
            _customerRepository.Verify(x => x.GetCustomerById(id), Times.Once);
            _dogRepositoryMock.Verify(x => x.GetAllDogsByCustomerId(id), Times.Once);
        }

        [TestCase(22)]
        public void GetDogsByCustomerIdTest_WhenCustomerNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _customerRepository.Setup(x => x.GetCustomerById(id)).Verifiable();
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetDogsByCustomerId(id));
            _customerRepository.Verify(x => x.GetCustomerById(id), Times.Once);
            _dogRepositoryMock.Verify(x => x.GetAllDogsByCustomerId(id), Times.Never);
        }
    }
}