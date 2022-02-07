using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
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

        [Test]
        public void GetPassportByIdTest()
        {
            //given
            List<Passport> Passports = new List<Passport>() {
              new Passport()
                {
                  FirstName = "Иванов",
                  LastName = "Иван",
                  DateOfBirth = new DateTime( 1987, 11, 11),
                  Seria = "4556",
                  Number = "123456",
                  IssueDate = new DateTime( 1987, 11, 11),
                  Division = "МВД по РТ",
                  DivisionCode = "160-098",
                  Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                  IsDeleted = false
                },
              new Passport()
                {
                  FirstName = "Мария",
                  LastName = "Нефедова",
                  DateOfBirth = new DateTime(1234, 11, 1),
                  Seria = "1234",
                  Number = "567890",
                  IssueDate = new DateTime(1564, 1, 1),
                  Division = "МВД по Верхне-услонскому району",
                  DivisionCode = "234-567",
                  Registration = "г. Иннополис, ул. Спортивная, д. 126, кв. 33",
                  IsDeleted = false
                },
              new Passport()
                {
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
                }
            };

            _context.Passports.AddRange(Passports);
            _context.SaveChanges();

            var expected =
              new Passport()
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

        [Test]
        public void AddPassportTest()
        {
            //given
            var passport =
             new Passport()
             {
                 FirstName = "Денис",
                 LastName = "Денискин",
                 DateOfBirth = new DateTime(1999, 2, 3),
                 Seria = "3456",
                 Number = "876543",
                 IssueDate = new DateTime(1976, 5, 23),
                 Division = "МВД",
                 DivisionCode = "345-555",
                 Registration = "г. Казань, ул. Академика Павлова, д. 10, кв. 90",
             };

            var expected =
             new Passport()
             {
                 Id = 1,
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
            _rep.AddPassport(passport);
            var actual = _context.Passports.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void UpdatePassportTest()
        {
            //given
            List<Passport> Passports = new List<Passport>() {
              new Passport()
                {
                  FirstName = "Иванов",
                  LastName = "Иван",
                  DateOfBirth = new DateTime( 1987, 11, 11),
                  Seria = "4556",
                  Number = "123456",
                  IssueDate = new DateTime( 1987, 11, 11),
                  Division = "МВД по РТ",
                  DivisionCode = "160-098",
                  Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                  IsDeleted = false
                },
              new Passport()
                {
                  FirstName = "Мария",
                  LastName = "Нефедова",
                  DateOfBirth = new DateTime(1234, 11, 1),
                  Seria = "1234",
                  Number = "567890",
                  IssueDate = new DateTime(1564, 1, 1),
                  Division = "МВД по Верхне-услонскому району",
                  DivisionCode = "234-567",
                  Registration = "г. Иннополис, ул. Спортивная, д. 126, кв. 33",
                  IsDeleted = false
                },
              new Passport()
                {
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
                }
            };

            _context.Passports.AddRange(Passports);
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
            _rep.UpdatePassport(newPassport);
            var actual = _context.Passports.FirstOrDefault(z => z.Id == newPassport.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

    }
}
