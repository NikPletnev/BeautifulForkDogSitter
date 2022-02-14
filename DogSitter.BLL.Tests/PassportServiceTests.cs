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
        private readonly Mock<IPassportRepository> _passportRepositoryMock;
        private readonly IMapper _mapper;
        private readonly PassportService _service;

        public PassportServiceTests()
        {
            _passportRepositoryMock = new Mock<IPassportRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new PassportService(_passportRepositoryMock.Object, _mapper);
        }


        [TestCaseSource(typeof(GetByIdAndUpdatePassportTestCaseSource))]
        public void UpdatePassportTest(int id, Passport entity, PassportModel model)
        {
            //given
            _passportRepositoryMock.Setup(x => x.UpdatePassport(entity)).Verifiable();
            _passportRepositoryMock.Setup(x => x.GetPassportById(id)).Returns(entity);
            //when       
            _service.UpdatePassport(id, model);
            //then
            Assert.AreEqual(model.IsDeleted, entity.IsDeleted);
            _passportRepositoryMock.Verify();
            _passportRepositoryMock.Verify(x => x.GetPassportById(id), Times.Once);
            _passportRepositoryMock.Verify(x => x.UpdatePassport(entity), Times.Once);
        }

        [TestCase(100)]
        public void UpdatePassportTest_WhenPassportNotFound_ShouldThrowServiceNotFoundExeption(int id)
        {
            //given
            _passportRepositoryMock.Setup(x => x.UpdatePassport(It.IsAny<Passport>()));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.UpdatePassport(id, new PassportModel()));
        }

        [TestCase(111)]
        public void UpdatePassportTest_WhenNotEnoughDataAboutPassport_ShouldThrowServiceNotEnoughDataExeption(int id)
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

            _passportRepositoryMock.Setup(x => x.AddPassport(It.IsAny<Passport>())).Verifiable();
            //when         
             _service.AddPassport(model);
            //then
            _passportRepositoryMock.Verify();
        }

        [TestCaseSource(typeof(AddPassportNegativeTestCaseSource))]
        public void AddPassportTest_WhenNotEnoughDataAboutPassport_ShouldThrowServiceNotEnoughDataExeption(PassportModel passport)
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
            _passportRepositoryMock.Setup(x => x.GetPassportById(id)).Returns(entity).Verifiable();
            //when
            PassportModel actual = _service.GetPassportById(id);
            //then
            Assert.AreEqual(expected, actual);
            _passportRepositoryMock.Verify();
        }

        [TestCase(11)]
        public void GetPassportByIdTest_WhenPassportNotFound_ShouldThrowServiceNotFoundExeption(int id)
        {
            //given
            _passportRepositoryMock.Setup(x => x.GetPassportById(id)).Verifiable();
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.GetPassportById(id));
            _passportRepositoryMock.Verify();
        }
    }
}
