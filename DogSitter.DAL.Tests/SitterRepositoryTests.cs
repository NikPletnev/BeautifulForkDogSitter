using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
                IsDeleted = false
            };

            _repository.Update(expected);
            var actual = _context.Sitters.First(x => x.Id == sitter.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Information, actual.Information);
        }

        [Test]
        public void UodateIsDeleteTest()
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

        [TestCaseSource(typeof(GetAllSittersWithWorkTimeBySubwayStationTestCaseSource))]
        public void GetAllSittersWithWorkTimeBySubwayStationTest(SubwayStation subwayStation,
            List<Sitter> sitters, List<Sitter> expected)
        {
            //given
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();

            //when
            var actual = _sitterRepository.GetAllSittersWithWorkTimeBySubwayStation(subwayStation);

            //then
            Assert.AreEqual(expected, actual);
            Assert.That(expected[0].WorkTime.Count == actual[0].WorkTime.Count);
        }
    }
}
