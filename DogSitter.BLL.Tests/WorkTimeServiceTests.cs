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
    public class WorkTimeServiceTests
    {
        private readonly Mock<IWorkTimeRepository> _workTimeRepositoryMock;
        private readonly IMapper _mapper;
        private WorkTimeService _service;
        private WorkTimeTestMocks _workTimeMocks;

        public WorkTimeServiceTests()
        {
            _workTimeRepositoryMock = new Mock<IWorkTimeRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
        }

        [SetUp]
        public void SetUp()
        {
            _service = new WorkTimeService(_workTimeRepositoryMock.Object, _mapper);
            _workTimeMocks = new WorkTimeTestMocks();
        }

        [Test]
        public void GetWorkTimeByIdTest()
        {
            //given 
            var expected = _workTimeMocks.GetMockWorkTime();
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(expected.Id)).Returns(expected);

            //when 
            var actual = _service.GetWorkTimeById(3);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(expected.Start, actual.Start);
            Assert.AreEqual(expected.End, actual.End);
            Assert.AreEqual(expected.Weekday, actual.Weekday);
            _workTimeRepositoryMock.Verify(m => m.GetWorkTimeById(expected.Id), Times.Once);
        }

        [Test]
        public void GetWorkTimeByIdNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<ServiceNotFoundExeption>(() => _service.GetWorkTimeById(0));
        }

        [Test]
        public void AddWorkTimeTest()
        {
            //given
            _workTimeRepositoryMock.Setup(m => m.AddWorkTime(It.IsAny<WorkTime>()));

            //when 
            _service.AddWorkTime(It.IsAny<WorkTimeModel>());

            //then
            _workTimeRepositoryMock.Verify(m => m.AddWorkTime(It.IsAny<WorkTime>()), Times.Once);
        }

        [Test]
        public void UpdateWorkTimeTest()
        {
            //given
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>()));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(new WorkTime());

            //when
            _service.UpdateWorkTime(new WorkTimeModel());

            //then
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(It.IsAny<WorkTime>()), Times.Once());
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(
                new WorkTime(), true), Times.Never());
        }

        [Test]
        public void UpdateWorkTimeNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>()));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<ServiceNotFoundExeption>(() => _service.UpdateWorkTime(new WorkTimeModel()));
        }

        [Test]
        public void DeleteWorkTimeTest()
        {
            //given
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), true));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(new WorkTime());

            //when
            _service.DeleteWorkTime(new WorkTimeModel()); 

            //then
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), true), Times.Once());
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(
                It.IsAny<WorkTime>()), Times.Never());
        }

        [Test]
        public void DeleteWorkTimeNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), true));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<ServiceNotFoundExeption>(() => _service.DeleteWorkTime(new WorkTimeModel()));
        }

        [Test]
        public void RestoreWorkTimeTest()
        {
            //given
            _workTimeRepositoryMock.Setup(m => m.RestoreWorkTime(It.IsAny<WorkTime>(), false));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(new WorkTime());

            //when
            _service.RestoreWorkTime(new WorkTimeModel());

            //then
            _workTimeRepositoryMock.Verify(m => m.RestoreWorkTime(It.IsAny<WorkTime>(), false), Times.Once());
        }

        [Test]
        public void RestoreWorkTimeNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.RestoreWorkTime(It.IsAny<WorkTime>(), false));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<ServiceNotFoundExeption>(() => _service.RestoreWorkTime(new WorkTimeModel()));
        }
    }
}