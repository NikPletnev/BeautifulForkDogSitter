using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class TimesheetRepositoryTests
    {
        private DogSitterContext _context;
        private TimesheetRepository _timesheetRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "TimesheetTests")
            .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _timesheetRepository = new TimesheetRepository(_context);
        }

        [TestCaseSource(typeof(TimesheetGetByTestCaseSourse))]
        public void GetTimesheetByIdTest(int id, Timesheet expectdTimesheet)
        {
            //given 
            _context.Timesheets.Add(expectdTimesheet);

            //when 
            var actual = _timesheetRepository.GetTimesheetById(id);

            //then 
            Assert.AreEqual(expectdTimesheet, actual);

        }
    }
}


