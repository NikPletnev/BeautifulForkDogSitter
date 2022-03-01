using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class WorkTimeRepositoryTests
    {
        private DogSitterContext _context;
        private WorkTimeRepository _workTimeRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "WorkTimeTests")
            .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _workTimeRepository = new WorkTimeRepository(_context);

            var workTimes = WorkTimeMock.GetWorkTimes();
            _context.WorkTimes.AddRange(workTimes);

            _context.SaveChanges();
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetWorkTimeByIdTest(int id)
        {
            //given
            var expected = _context.WorkTimes.Find(id);

            //when
            var actual = _workTimeRepository.GetWorkTimeById(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddWorkTimeTest()
        {
            //given
            var expected = WorkTimeMock.GetWorkTime();
            var sitter = new Sitter();

            //when
            _workTimeRepository.AddWorkTime(expected, sitter);

            var actual = _context.WorkTimes.FirstOrDefault(a => a.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateWorkTimeTest()
        {
            //given
            var workTime = WorkTimeMock.GetWorkTime();
            _context.WorkTimes.Add(workTime);

            _context.SaveChanges();

            var updatedWorkTime = new WorkTime()
            {
                Id = workTime.Id,
                Start = DateTime.Now,
                End = DateTime.Now,
                Weekday = Weekday.Thursday,
                IsDeleted = workTime.IsDeleted
            };

            //when
            _workTimeRepository.UpdateWorkTime(workTime, updatedWorkTime);

            var actual = _context.WorkTimes.FirstOrDefault(a => a.Id == workTime.Id);

            //then
            Assert.AreEqual(updatedWorkTime.Id, actual.Id);
            Assert.AreEqual(updatedWorkTime.Start, actual.Start);
            Assert.AreEqual(updatedWorkTime.End, actual.End);
            Assert.AreEqual(updatedWorkTime.Weekday, actual.Weekday);
            Assert.AreEqual(updatedWorkTime.IsDeleted, actual.IsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateOrDeleteWorkTimeTest(bool isDeleted)
        {
            //given
            var workTime = WorkTimeMock.GetWorkTime();

            //when
            _workTimeRepository.UpdateOrDeleteWorkTime(workTime, isDeleted);

            //then
            Assert.AreEqual(workTime.IsDeleted, isDeleted);
        }
    }
}
