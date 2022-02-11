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
using System;

namespace DogSitter.BLL.Tests
{
    public class PassportServiceTests
    {
        private readonly Mock<IPassportRepository> _PassportRepositoryMock;
        private readonly IMapper _mapper;
        private readonly PassportService _service;

        public PassportServiceTests()
        {
            _PassportRepositoryMock = new Mock<IPassportRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new PassportService(_PassportRepositoryMock.Object, _mapper);
        }


        [TestCaseSource(typeof(GetByIdAndUpdatePassportTestCaseSource))]
        public void UpdatePassportTest(int id, Passport entity, PassportModel model)
        {
            //given
            _PassportRepositoryMock.Setup(x => x.UpdatePassport(entity)).Verifiable();
            _PassportRepositoryMock.Setup(x => x.GetPassportById(id)).Returns(entity);
            //when       
            //then
            Assert.DoesNotThrow(() => _service.UpdatePassport(id, model));
            Assert.Pass();
            _PassportRepositoryMock.Verify();
            _PassportRepositoryMock.Verify(x => x.GetPassportById(id), Times.Once);
            _PassportRepositoryMock.Verify(x => x.UpdatePassport(entity), Times.Once);
        }

        [TestCase(1)]
        [TestCase(11)]
        [TestCase(100)]
        public void UpdatePassportTest_WhenPassportNotFound_ShouldServiceNotFoundExeption(int id)
        {
            //given
            _PassportRepositoryMock.Setup(x => x.UpdatePassport(It.IsAny<Passport>()));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.UpdatePassport(id, new PassportModel()));
        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(111)]
        public void UpdatePassportTest_WhenNotEnoughDataAboutPassport_ShouldServiceNotEnoughDataExeption(int id)
        {
            //given

            PassportModel model = new PassportModel()
            {
                FirstName = "",
                LastName = "Иван",
                DateOfBirth = new DateTime(1987, 11, 11),
                Seria = "4556",
                Number = "",
                IssueDate = new DateTime(1987, 11, 11),
                Division = "МВД по РТ",
                DivisionCode = "160-098",
                Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                IsDeleted = false
            };

            //when

            //then

            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.UpdatePassport(id, model));
        }

        [Test]
        public void AddPassportTest()
        {
            //given
            PassportModel model = new PassportModel()
            {
                FirstName = "Иванов",
                LastName = "Иван",
                DateOfBirth = new DateTime(1987, 11, 11),
                Seria = "4556",
                Number = "123456",
                IssueDate = new DateTime(1987, 11, 11),
                Division = "МВД по РТ",
                DivisionCode = "160-098",
                Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                IsDeleted = false
            };

            _PassportRepositoryMock.Setup(x => x.AddPassport(It.IsAny<Passport>())).Verifiable();
            //when         
             _service.AddPassport(model);
            //then
            _PassportRepositoryMock.Verify();
        }

        [TestCaseSource(typeof(AddPassportNegativeTestCaseSource))]
        public void AddPassportTest_WhenNotEnoughDataAboutPassport_ShouldServiceNotEnoughDataExeption(PassportModel passport)
        {
            //given
            //when
            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.AddPassport(passport));
        }

        [TestCaseSource(typeof(GetByIdAndUpdatePassportTestCaseSource))]
        public void GetPassportByIdTest(int id, Passport entity, PassportModel expected )
        {
            //given
            _PassportRepositoryMock.Setup(x => x.GetPassportById(id)).Returns(entity).Verifiable();
            //when
            PassportModel actual = _service.GetPassportById(id);
            //then
            Assert.AreEqual(expected, actual);
            _PassportRepositoryMock.Verify();
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(11)]
        public void GetPassportByIdTest_WhenPassportNotFound_ShouldServiceNotFoundExeption(int id)
        {
            //given
            _PassportRepositoryMock.Setup(x => x.GetPassportById(id)).Verifiable();
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.GetPassportById(id));
            _PassportRepositoryMock.Verify();
        }
    }
}
