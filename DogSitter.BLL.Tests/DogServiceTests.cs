using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.BLL.Tests.TestCaseSource.DogService;
using DogSitter.BLL.Tests.TestCaseSource.DogServiceTestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class DogServiceTests
    {
        private  Mock<IDogRepository> _dogRepositoryMock;
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<IUserRepository> _userRepositoryMock;
        private  IMapper _mapper;
        private  DogService _service;

        [SetUp]
        public void Setup()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();  
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new DogService(_mapper, _dogRepositoryMock.Object, _customerRepository.Object, _userRepositoryMock.Object);
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


        [TestCaseSource(typeof(GetAllDogsTestCaseSource))]
        public void GetAllDogsTestMustReturnAllDogs(List<Dog> dogs, List<DogModel> expected)
        {
            //given
            _dogRepositoryMock.Setup(x => x.GetAllDogs()).Returns(dogs);

            //when
            var actual = _service.GetAllDogs();

            //then
            Assert.AreEqual(actual, expected);
            _dogRepositoryMock.Verify(x => x.GetAllDogs(), Times.Once);
        }

        [TestCaseSource(typeof(GetDogsForTestTestCaseSource))]
        public void AddDogMustAddDog(DogModel dogs)
        {
            //given
            _dogRepositoryMock.Setup(x => x.AddDog(It.IsAny<Dog>()));
            //when
            _service.AddDog(dogs);
            //then
            _dogRepositoryMock.Verify(x => x.AddDog(It.IsAny<Dog>()), Times.Once);
        }

        [TestCaseSource(typeof(GetDogForTestExeptionTestCaseSource))]
        public void AddDogMustThrowServieNotEnoughDataExeption(DogModel dogs, Dog dogEntity)
        {
            //given
            _dogRepositoryMock.Setup(x => x.AddDog(It.IsAny<Dog>()));
            var expectedMessage = "There is not enough data to create new dog";
            //when

            //then
            ServiceNotEnoughDataExeption ex = Assert.Throws<ServiceNotEnoughDataExeption>(() =>
           _service.AddDog(dogs));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(GetDogByIdTestCaseSource))]
        public void RestoreDogTestMustDeleteDog(int id, Dog dog, DogModel expected)
        {
            //gicen
            _dogRepositoryMock.Setup(x => x.UpdateDog(id, false));
            _dogRepositoryMock.Setup(x => x.GetDogById(id)).Returns(dog);
            //when
            _service.RestoreDog(id);
            //then
            _dogRepositoryMock.Verify(x => x.UpdateDog(id, false), Times.Once);
            _dogRepositoryMock.Verify(x => x.GetDogById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetDogByIdTestCaseSource))]
        public void RestoreAddressTestMustThrowEntityNotFoundExeption(int id, Dog dog, DogModel expected)
        {
            //gicen
            Dog nullDog = null;
            _dogRepositoryMock.Setup(x => x.UpdateDog(id, false));
            _dogRepositoryMock.Setup(x => x.GetDogById(id)).Returns(nullDog);
            var expectedMessage = $"Dog {id} was not found";
            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.RestoreDog(id));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

    }
}

















