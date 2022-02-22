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
        private Mock<IPassportRepository> _passportRepositoryMock;
        private IMapper _mapper;
        private PassportService _service;


        [SetUp]
        public void Setup()
        {
            _passportRepositoryMock = new Mock<IPassportRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new PassportService(_passportRepositoryMock.Object, _mapper);
        }


        [TestCaseSource(typeof(GetByIdAndUpdatePassportTestCaseSource))]
        public void UpdatePassportTest(int id, Passport entity, PassportModel model)
        {
            //given

            _passportRepositoryMock.Setup(x => x.UpdatePassport(entity, It.IsAny<Passport>())).Verifiable();
            _passportRepositoryMock.Setup(x => x.GetPassportById(id)).Returns(entity);
            //when       
            _service.UpdatePassport(id, model);
            //then
            _passportRepositoryMock.Verify(x => x.GetPassportById(id), Times.Once);
            _passportRepositoryMock.Verify(x => x.UpdatePassport(entity, It.IsAny<Passport>()), Times.Once);
        }

        [TestCase(100)]
        public void UpdatePassportTest_WhenPassportNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _passportRepositoryMock.Setup(x => x.UpdatePassport(It.IsAny<Passport>(), It.IsAny<Passport>()));
            _passportRepositoryMock.Setup(x => x.GetPassportById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.UpdatePassport(id, new PassportModel()));
            _passportRepositoryMock.Verify(x => x.UpdatePassport(It.IsAny<Passport>(), It.IsAny<Passport>()), Times.Never);
            _passportRepositoryMock.Verify(x => x.GetPassportById(id), Times.Once);
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
            _passportRepositoryMock.Verify(x => x.UpdatePassport(It.IsAny<Passport>(), It.IsAny<Passport>()), Times.Never);
            _passportRepositoryMock.Verify(x => x.GetPassportById(id), Times.Never);
        }
    }
}
