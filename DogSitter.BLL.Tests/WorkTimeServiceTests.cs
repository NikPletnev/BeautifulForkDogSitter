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
    public class WorkTimeServiceTests
    {
        private Mock<IWorkTimeRepository> _workTimeRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private IMapper _mapper;
        private WorkTimeService _service;
        private WorkTimeTestMocks _workTimeMocks;

        [SetUp]
        public void Setup()
        {
            _workTimeRepositoryMock = new Mock<IWorkTimeRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new WorkTimeService(_workTimeRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
            _workTimeMocks = new WorkTimeTestMocks();
        }

        [TestCase(77)]
        public void AddWorkTimeTest(int expected)
        {
            //given
            var workTime = _workTimeMocks.GetMockWorkTime();

            _workTimeRepositoryMock.Setup(m => m.AddWorkTime(workTime, It.IsAny<Sitter>()));
            _userRepositoryMock.Setup(x => x.GetUserById(workTime.Sitter.Id)).Returns(workTime.Sitter);

            //when 
            _service.AddWorkTime(workTime.Sitter.Id, _mapper.Map<WorkTimeModel>(workTime));

            //then
            _workTimeRepositoryMock.Verify(m => m.AddWorkTime(It.IsAny<WorkTime>(), It.IsAny<Sitter>()), Times.Once);

        }

        [Test]
        public void UpdateWorkTimeTest()
        {
            //given
            var work = _workTimeMocks.GetMockWorkTime();
            WorkTimeModel workTime = new WorkTimeModel()
            {
                Id = 1,
                End = new DateTime(),
                Start = new DateTime(),
                Weekday = Weekday.Sunday,
                Sitter = new SitterModel()
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Password = "Password1",
                    IsDeleted = false
                }
            };
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), It.IsAny<WorkTime>()));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(work);
            _userRepositoryMock.Setup(x => x.GetUserById(work.Sitter.Id)).Returns(work.Sitter);

            //when
            _service.UpdateWorkTime(workTime.Sitter.Id, workTime.Id, workTime);

            //then
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), It.IsAny<WorkTime>()), Times.Once());
            _workTimeRepositoryMock.Verify(m => m.UpdateOrDeleteWorkTime(
                new WorkTime(), true), Times.Never());
        }

        [Test]
        public void UpdateWorkTimeNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.UpdateWorkTime(It.IsAny<WorkTime>(), It.IsAny<WorkTime>()));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<EntityNotFoundException>(() => _service.UpdateWorkTime(It.IsAny<int>(), It.IsAny<int>(), new WorkTimeModel()));
        }

        [Test]
        public void DeleteWorkTimeTest()
        {
            //given
            var work = _workTimeMocks.GetMockWorkTime();
            _workTimeRepositoryMock.Setup(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), true));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(work);
            _userRepositoryMock.Setup(x => x.GetUserById(work.Sitter.Id)).Returns(work.Sitter);

            //when
            _service.DeleteWorkTime(work.Sitter.Id, It.IsAny<int>());

            //then
            _workTimeRepositoryMock.Verify(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), true), Times.Once());
            _workTimeRepositoryMock.Verify(m => m.UpdateWorkTime(
                It.IsAny<WorkTime>(), It.IsAny<WorkTime>()), Times.Never());
        }

        [Test]
        public void DeleteWorkTimeNegativeTest()
        {

            _workTimeRepositoryMock.Setup(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), true));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteWorkTime(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void RestoreWorkTimeTest()
        {
            //given
            _workTimeRepositoryMock.Setup(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), false));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns(new WorkTime());

            //when
            _service.RestoreWorkTime(It.IsAny<int>());

            //then
            _workTimeRepositoryMock.Verify(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), false), Times.Once());
        }

        [Test]
        public void RestoreWorkTimeNegativeTest()
        {
            _workTimeRepositoryMock.Setup(m => m.UpdateOrDeleteWorkTime(It.IsAny<WorkTime>(), false));
            _workTimeRepositoryMock.Setup(m => m.GetWorkTimeById(It.IsAny<int>())).Returns((WorkTime)null);

            Assert.Throws<EntityNotFoundException>(() => _service.RestoreWorkTime(It.IsAny<int>()));
        }
    }
}