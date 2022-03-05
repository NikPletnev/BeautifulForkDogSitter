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

namespace DogSitter.BLL.Tests
{
    public class SubwayStationSubwayStationTests
    {
        private Mock<ISubwayStationRepository> _subwayStationRepositoryMock;
        private IMapper _mapper;
        private SubwayStationService _subwayStationService;
        private SubwayStationTestCaseSource _subwayStationMocks;

        [SetUp]
        public void Setup()
        {
            _subwayStationRepositoryMock = new Mock<ISubwayStationRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _subwayStationService = new SubwayStationService(_subwayStationRepositoryMock.Object, _mapper);
            _subwayStationMocks = new SubwayStationTestCaseSource();
        }

        [Test]
        public void GetAllSubwayStationsTest()
        {
            //given
            var expected = _subwayStationMocks.GetSubwayStations();
            _subwayStationRepositoryMock.Setup(m => m.GetAllSubwayStations()).Returns(expected);

            //when
            var actual = _subwayStationService.GetAllSubwayStations();

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count, expected.Count);
            _subwayStationRepositoryMock.Verify(m => m.GetAllSubwayStations(), Times.Once);
        }

        [Test]
        public void GetAllSubwayStationsWhereSitterExistTest()
        {
            //given
            var expected = _subwayStationMocks.GetSubwayStations();
            _subwayStationRepositoryMock.Setup(m => m.GetAllSubwayStationsWhereSitterExist()).Returns(expected);

            //when
            var actual = _subwayStationService.GetAllSubwayStationsWhereSitterExist();

            //then
            Assert.IsNotNull(actual);
            _subwayStationRepositoryMock.Verify(m => m.GetAllSubwayStationsWhereSitterExist(), Times.Once);
        }

        [Test]
        public void GetSubwayStationByIdTest()
        {
            //given 
            var expected = _subwayStationMocks.GetSubwayStation();
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(expected.Id)).Returns(expected);

            //when 
            var actual = _subwayStationService.GetSubwayStationById(3);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Name, expected.Name);
            _subwayStationRepositoryMock.Verify(m => m.GetSubwayStationById(expected.Id), Times.Once);
        }

        [Test]
        public void GetSubwayStationByIdNegativeTest()
        {
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(It.IsAny<int>()))
                .Returns((SubwayStation)null);

            Assert.Throws<EntityNotFoundException>(() => _subwayStationService.GetSubwayStationById(0));
        }

        [TestCase(77)]
        public void AddSubwayStationTest(int expected)
        {
            //given
            _subwayStationRepositoryMock.Setup(m => m.AddSubwayStation(It.IsAny<SubwayStation>())).Returns(expected);

            //when 
            var actual = _subwayStationService.AddSubwayStation(It.IsAny<SubwayStationModel>());

            //then
            _subwayStationRepositoryMock.Verify(m => m.AddSubwayStation(It.IsAny<SubwayStation>()), Times.Once);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void UpdateSubwayStationTest()
        {
            //given
            _subwayStationRepositoryMock.Setup(m => m.UpdateSubwayStation(
                It.IsAny<SubwayStation>(), It.IsAny<SubwayStation>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(It.IsAny<int>()))
                .Returns(new SubwayStation());

            //when
            _subwayStationService.UpdateSubwayStation(It.IsAny<int>(), new SubwayStationModel());

            //then
            _subwayStationRepositoryMock.Verify(m => m.UpdateSubwayStation(
                It.IsAny<SubwayStation>(), It.IsAny<SubwayStation>()), Times.Once());
        }

        [Test]
        public void UpdateSubwayStationNegativeTest()
        {
            _subwayStationRepositoryMock.Setup(m => m.UpdateSubwayStation(
                It.IsAny<SubwayStation>(), It.IsAny<SubwayStation>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(It.IsAny<int>()))
                .Returns((SubwayStation)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _subwayStationService.UpdateSubwayStation(It.IsAny<int>(), new SubwayStationModel()));
        }

        [Test]
        public void DeleteSubwayStationTest()
        {
            //given
            _subwayStationRepositoryMock.Setup(m => m.UpdateOrDeleteSubwayStation(
               It.IsAny<SubwayStation>(), It.IsAny<bool>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(It.IsAny<int>()))
                .Returns(new SubwayStation());

            //when
            _subwayStationService.DeleteSubwayStation(It.IsAny<int>());

            //then
            _subwayStationRepositoryMock.Verify(m => m.UpdateOrDeleteSubwayStation(
               It.IsAny<SubwayStation>(), true), Times.Once());
        }

        [Test]
        public void DeleteSubwayStationNegativeTest()
        {
            _subwayStationRepositoryMock.Setup(m => m.UpdateOrDeleteSubwayStation(
                It.IsAny<SubwayStation>(), It.IsAny<bool>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(
                It.IsAny<int>())).Returns((SubwayStation)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _subwayStationService.DeleteSubwayStation(It.IsAny<int>()));
        }

        [Test]
        public void RestoreSubwayStationTest()
        {
            //given
            _subwayStationRepositoryMock.Setup(m => m.UpdateOrDeleteSubwayStation(
               It.IsAny<SubwayStation>(), It.IsAny<bool>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(It.IsAny<int>()))
                .Returns(new SubwayStation());

            //when
            _subwayStationService.RestoreSubwayStation(It.IsAny<int>());

            //then
            _subwayStationRepositoryMock.Verify(m => m.UpdateOrDeleteSubwayStation(
               It.IsAny<SubwayStation>(), false), Times.Once());
        }

        [Test]
        public void RestoreSubwayStationNegativeTest()
        {
            _subwayStationRepositoryMock.Setup(m => m.UpdateOrDeleteSubwayStation(
                It.IsAny<SubwayStation>(), It.IsAny<bool>()));
            _subwayStationRepositoryMock.Setup(m => m.GetSubwayStationById(
                It.IsAny<int>())).Returns((SubwayStation)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _subwayStationService.DeleteSubwayStation(It.IsAny<int>()));
        }
    }
}
