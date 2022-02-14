using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

            var workTimes = WorkTimeTestCaseSourse.GetWorkTimes();
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
            Assert.That(actual.IsDeleted == false | true);
        }

        [Test]
        public void AddWorkTimeTest()
        {
            //given
            var expected = WorkTimeTestCaseSourse.GetWorkTime();

            //when
            _workTimeRepository.AddWorkTime(expected);

            var actual = _context.WorkTimes.FirstOrDefault(a => a.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateWorkTimeTest()
        {
            //given
            var workTime = WorkTimeTestCaseSourse.GetWorkTime();
            _context.WorkTimes.Add(workTime);

            _context.SaveChanges();

            var expected = new WorkTime()
            {
                Id = workTime.Id,
                Start = DateTime.Now,
                End = DateTime.Now,
                Weekday = Weekday.Thursday,
                Sitter = new List<Sitter>(),
                IsDeleted = workTime.IsDeleted
            };

            //when
            _workTimeRepository.UpdateWorkTime(expected);

            var actual = _context.WorkTimes.FirstOrDefault(a => a.Id == workTime.Id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Start, actual.Start);
            Assert.AreEqual(expected.End, actual.End);
            Assert.AreEqual(expected.Weekday, actual.Weekday);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
            Assert.AreEqual(expected.Sitter, actual.Sitter);
        }

        [Test]
        public void UpdateIsDeleteWorkTimeTest()
        {
            //given
            var workTime = WorkTimeTestCaseSourse.GetWorkTime();

            //when
            _workTimeRepository.UpdateWorkTime(workTime, true);

            //then
            Assert.AreEqual(workTime.IsDeleted, true);
        }

        [Test]
        public void RestoreWorkTimeTest()
        {
            //given
            var workTime = WorkTimeTestCaseSourse.GetWorkTime();

            //when
            _workTimeRepository.RestoreWorkTime(workTime, false);

            //then
            Assert.AreEqual(workTime.IsDeleted, false);
        }
    }
}
