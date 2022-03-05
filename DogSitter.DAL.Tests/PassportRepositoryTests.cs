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
    public class PassportRepositoryTests
    {
        private DogSitterContext _context;
        private PassportRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("PassportTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new PassportRepository(_context);
        }

        [TestCaseSource(typeof(PassportTestCaseSource))]
        public void GetPassportByIdTest(List<Passport> passports)
        {
            //given
            _context.Passports.AddRange(passports);
            _context.SaveChanges();
            var expected = new Passport()
            {
                Id = 3,
                FirstName = "Денис",
                LastName = "Денискин",
                DateOfBirth = new DateTime(1999, 2, 3),
                Seria = "3456",
                Number = "876543",
                IssueDate = new DateTime(1976, 5, 23),
                Division = "МВД",
                DivisionCode = "345-555",
                Registration = "г. Казань, ул. Академика Павлова, д. 10, кв. 90",
                IsDeleted = false
            };

            //when
            var actual = _rep.GetPassportById(3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(PassportTestCaseSource))]
        public void UpdatePassportTest(List<Passport> passports)
        {
            //given            
            _context.Passports.AddRange(passports);
            _context.SaveChanges();
            var newPassport =
              new Passport()
              {
                  Id = 3,
                  FirstName = "Роман",
                  LastName = "Романов",
                  DateOfBirth = new DateTime(1989, 3, 2),
                  Seria = "6789",
                  Number = "875678",
                  IssueDate = new DateTime(1946, 4, 24),
                  Division = "МВД МВД",
                  DivisionCode = "345-333",
                  Registration = "г. Казань, ул. Академика Завойского, д. 10, кв. 90",
              };

            var passport = _context.Passports.FirstOrDefault(x => x.Id == 3);

            var expected =
              new Passport()
              {
                  Id = 3,
                  FirstName = "Роман",
                  LastName = "Романов",
                  DateOfBirth = new DateTime(1989, 3, 2),
                  Seria = "6789",
                  Number = "875678",
                  IssueDate = new DateTime(1946, 4, 24),
                  Division = "МВД МВД",
                  DivisionCode = "345-333",
                  Registration = "г. Казань, ул. Академика Завойского, д. 10, кв. 90",
                  IsDeleted = false
              };

            //when
            _rep.UpdatePassport(passport, newPassport);
            var actual = _context.Passports.FirstOrDefault(z => z.Id == newPassport.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

    }
}
