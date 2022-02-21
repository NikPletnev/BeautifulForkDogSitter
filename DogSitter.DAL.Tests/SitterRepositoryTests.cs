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
    public class SitterRepositoryTests
    {
        private DogSitterContext _context;
        private SitterRepository _repository;
        private SitterTestCaseSourse _sitterTestCaseSourse;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("SitterTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new SitterRepository(_context);
            var sitters = SitterTestCaseSourse.GetSitters();
            _context.Sitters.AddRange(sitters);

            _context.SaveChanges();

            _repository = new SitterRepository(_context);
        }

        [Test]
        public void GetAllSitterTest()
        {
            var expected = _context.Sitters.Where(e => !e.IsDeleted);

            var actual = _repository.GetAll();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Where(e => e.IsDeleted), actual.Where(a => a.IsDeleted));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetSitterByIdTest(int id)
        {
            var expected = _context.Sitters.Find(id);

            var actual = _repository.GetById(id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddSitterTest()
        {
            var expected = SitterTestCaseSourse.GetSitter();

            _repository.Add(expected);

            var actual = _context.Sitters.FirstOrDefault(x => x.Id == expected.Id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateSitterTest()
        {
            var sitter = SitterTestCaseSourse.GetSitter();
            _context.Sitters.Add(sitter);
            _context.SaveChanges();

            var expected = new Sitter()
            {
                Id = sitter.Id,
                FirstName = "ХьюгоCHANGE",
                LastName = "ФлюгерCHANGE",
                Password = "flug123",
                Information = "SITTERs GOD CHANGE GOD",
                Verified = true,
                Orders = new List<Order>(),
                WorkTime = new List<WorkTime>(),
                Contacts = new List<Contact>(),
                Passport = new Passport()
                {
                    FirstName = " ",
                    LastName = " ",
                    DateOfBirth = DateTime.Now,
                    Seria = " ",
                    Number = " ",
                    IssueDate = DateTime.Now,
                    Division = " ",
                    DivisionCode = " "
                },
                IsDeleted = false
            };

            _repository.Update(expected);
            var actual = _context.Sitters.First(x => x.Id == sitter.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Information, actual.Information);
            Assert.AreEqual(expected.Orders, actual.Orders);
            Assert.AreEqual(expected.WorkTime, actual.WorkTime);
            Assert.AreEqual(expected.Contacts, actual.Contacts);
            Assert.AreEqual(expected.Passport, actual.Passport);
        }

        [Test]
        public void UpdateIsDeleteTest()
        {
            var sitter = SitterTestCaseSourse.GetSitter();
            _context.Sitters.Add(sitter);
            _context.SaveChanges();

            _repository.Update(sitter.Id, true);

            Assert.AreEqual(sitter.IsDeleted, true);
        }

        [TestCaseSource(typeof(EditStateProfileSitterByIdTestCaseSource))]
        public void ConfirmProfileSitterByIdTest(int id, bool verify, List<Sitter> sitters)
        {
            //given
            _context.AddRange(sitters);
            _context.SaveChanges();

            //when
            _repository.EditProfileStateBySitterId(id, verify);
            var actual = _context.Sitters.FirstOrDefault(x => x.Id == id).Verified;

            //then
            Assert.AreEqual(actual, verify);
        }

        //[TestCaseSource(typeof(GetAllSittersByServiceIdTestCaseSource))]
        //public void GetAllSittersByServiceIdTest(int id, Serviсe service, List<Sitter> expected)
        //{
        //    //given
        //    _context.Services.AddRange(service);
        //    _context.SaveChanges();

        //    //when
        //    var actual = _repository.GetAllSitterByServiceId(id);

        //    //then
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCaseSource(typeof(GetAllSittersWithWorkTimeBySubwayStationTestCaseSource))]
        public void GetAllSittersWithWorkTimeBySubwayStationTest(SubwayStation subwayStation,
            List<Sitter> sitters, List<Sitter> expected)
        {
            //given
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();

            //when
            var actual = _repository.GetAllSittersWithWorkTimeBySubwayStation(subwayStation);

            //then
            Assert.AreEqual(expected, actual);
            Assert.That(expected[0].WorkTime.Count == actual[0].WorkTime.Count);
        }
    }
}
