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
    public class SitterServiceTests
    {
        private Mock<ISitterRepository> _sitterRepositoryMock;
        private Mock<ISubwayStationRepository> _subwayStationRepositoryMock;
        private IMapper _mapper;
        private SitterService _service;

        [SetUp]
        public void Setup()
        {
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _subwayStationRepositoryMock = new Mock<ISubwayStationRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new SitterService(_sitterRepositoryMock.Object, _subwayStationRepositoryMock.Object, _mapper);
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
