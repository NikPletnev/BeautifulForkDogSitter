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
    public class SitterServiceTests
    {
        private Mock<ISitterRepository> _sitterRepositoryMock;
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private Mock<ISubwayStationRepository> _subwayStationRepositoryMock;
        private SitterService _service;
        private IMapper _mapper;
        private SitterTestCaseSourse _sitterTestCase;

        [SetUp]
        public void Setup()
        {
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _subwayStationRepositoryMock = new Mock<ISubwayStationRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new SitterService(_sitterRepositoryMock.Object, _subwayStationRepositoryMock.Object, _mapper);
            _sitterTestCase = new SitterTestCaseSourse();
        }

        [Test]
        public void GEtAllSitters_ShouldReturnSitters()
        {
            var expected = SitterTestCaseSourse.GetMockSitters();
            _sitterRepositoryMock.Setup(x => x.GetAll()).Returns(expected);

            var actual = _service.GetAll();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            _sitterRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void GetSitterById()
        {
            var expected = SitterTestCaseSourse.GetMockSitter();
            _sitterRepositoryMock.Setup(x => x.GetById(expected.Id)).Returns(expected);

            var actual = _service.GetById(expected.Id);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Information, actual.Information);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
            _sitterRepositoryMock.Verify(m => m.GetById(expected.Id), Times.Once);
        }

        [Test]
        public void GetSItterByIDNegativeTest()
        {
            _sitterRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns((Sitter)null);

            Assert.Throws<EntityNotFoundException>(() => _service.GetById(0));
        }

        [Test]
        public void AddSitterTest()
        {
            _sitterRepositoryMock.Setup(x => x.Add(It.IsAny<Sitter>()));
            var sitterModel = SitterTestCaseSourse.GetMockSitterModel();

            _service.Add(sitterModel);

            _sitterRepositoryMock.Verify(x => x.Add(It.IsAny<Sitter>()), Times.Once());
        }

        [Test]
        public void UpdateSitterTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<Sitter>()));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Sitter());

            _service.Update(new SitterModel());

            _sitterRepositoryMock.Verify(x => x.Update(It.IsAny<Sitter>()), Times.Once());
            _sitterRepositoryMock.Verify(x => x.Update(1, true), Times.Never());
        }

        [Test]
        public void UpdateSitterNegativeTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<Sitter>()));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Sitter)null);

            Assert.Throws<EntityNotFoundException>(() => _service.Update(new SitterModel()));
        }

        [Test]
        public void DeleteSitterTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<bool>()));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Sitter());

            _service.DeleteById(0);

            _sitterRepositoryMock.Verify(x => x.Update(It.IsAny<int>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void DeleteSitterNegativeTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<bool>()));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Sitter)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteById(0));
        }

        [Test]
        public void RestoreSitterTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), true));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Sitter());

            _service.Restore(2);

            _sitterRepositoryMock.Verify(x => x.Update(It.IsAny<int>(), false),Times.Once());
        }

        [Test]
        public void RestoreSitterNegativeTest()
        {
            _sitterRepositoryMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<bool>()));
            _sitterRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Sitter)null);

            Assert.Throws<EntityNotFoundException>(() => _service.Restore(0));
        }

        [TestCase(1)]
        public void ConfirmProfileSitterByIdTest(int id)
        {
            //given
            Sitter sitter = new Sitter()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                IsDeleted = false,
                AddressId = 1,
                PassportId = 2,
                Verified = false
            };
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Returns(sitter).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditProfileStateBySitterId(id, true)).Verifiable();

            //when
            _service.ConfirmProfileSitterById(id);

            //then
            _sitterRepositoryMock.Verify(x => x.EditProfileStateBySitterId(id, true), Times.Once);
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(1)]
        public void ConfirmOrBlockProfileSitterByIdTest_WhenSitterNotFound_ShouldThrowServoceNotFoundExeption(int id)
        {
            //given           
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditProfileStateBySitterId(id, It.IsAny<bool>())).Verifiable();

            //when

            //then
            Assert.Throws<EntityNotFoundException>(() => _service.ConfirmProfileSitterById(id));
            Assert.Throws<EntityNotFoundException>(() => _service.BlockProfileSitterById(id));
            _sitterRepositoryMock.Verify(x => x.EditProfileStateBySitterId(id, It.IsAny<bool>()), Times.Never);
        }

        [TestCase(2)]
        public void BlockProfileSitterByIdTest(int id)
        {
            //given
            Sitter sitter = new Sitter()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                IsDeleted = false,
                AddressId = 1,
                PassportId = 2,
                Verified = true
            };
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Returns(sitter).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditProfileStateBySitterId(id, false)).Verifiable();

            //when
            _service.BlockProfileSitterById(id);

            //then
            _sitterRepositoryMock.Verify(x => x.EditProfileStateBySitterId(id, false), Times.Once);
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetAllSittersByServiceIdTestCaseSource))] 
        public void GetAllSittersByServiceIdTest(int id, Serviсe service, List<Sitter> sitters)
        {
            ////given
            //_serviceRepositoryMock.Setup(m => m.GetServiceById(id)).Returns(service);
            //_sitterRepositoryMock.Setup(m => m.GetAllSitterByServiceId(id)).Returns(sitters);

            ////when
            //var actual = _service.GetAllSitterByServiceId(id);

            ////then
            //_serviceRepositoryMock.Verify(m => m.GetServiceById(id), Times.Once);
            //_sitterRepositoryMock.Verify(m => m.GetAllSitterByServiceId(id), Times.Once);
            //Assert.That(actual[0].Services.Count == 0);
        }

        [Test]
        public void GetAllSittersByServiceIdNegativeTest()
        {
            //_serviceRepositoryMock.Setup(m => m.GetServiceById(It.IsAny<int>())).Returns((Serviсe)null);

            //Assert.Throws<EntityNotFoundException>(() => _service.GetAllSitterByServiceId(It.IsAny<int>()));
        }

        [TestCaseSource(typeof(GetAllSittersWithWorkTimeBySubwayStationTestCaseSource))]
        public void GetAllSittersWithWorkTimeBySubwayStationTest(SubwayStation subwayStation,
            SubwayStationModel subwayStationModel, List<Sitter> sitters)
        {
            //given
            _subwayStationRepositoryMock.Setup(ss => ss.GetSubwayStationById(subwayStation.Id))
                .Returns(subwayStation);
            _sitterRepositoryMock.Setup(s => s.GetAllSittersWithWorkTimeBySubwayStation(subwayStation))
                .Returns(sitters);

            //when
            var actual = _service.GetAllSittersWithWorkTimeBySubwayStation(subwayStationModel);

            //then
            _subwayStationRepositoryMock.Verify(ss => ss.GetSubwayStationById(subwayStation.Id), Times.Once);
            _sitterRepositoryMock.Verify(s =>
            s.GetAllSittersWithWorkTimeBySubwayStation(subwayStation), Times.Once);
        }

        [Test]
        public void GetAllSittersWithWorkTimeBySubwayStationNegativeTest()
        {
            _subwayStationRepositoryMock.Setup(ss => ss.GetSubwayStationById(It.IsAny<int>()))
                .Returns((SubwayStation)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _service.GetAllSittersWithWorkTimeBySubwayStation(new SubwayStationModel()));
        }
    };
}

