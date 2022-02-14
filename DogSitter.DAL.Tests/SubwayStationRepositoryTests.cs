using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests
{
    public class SubwayStationRepositoryTests
    {
        private DogSitterContext _context;
        private SubwayStationRepository _subwayStationRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "SubwayStationTests")
            .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _subwayStationRepository = new SubwayStationRepository(_context);

            var SubwayStations = SubwayStationTestCaseSourse.GetSubwayStations();
            _context.SubwayStations.AddRange(SubwayStations);

            _context.SaveChanges();
        }

        [Test]
        public void GetAllSubwayStationsTest()
        {
            // given
            var expected = _context.SubwayStations.Where(e => !e.IsDeleted);

            // when
            var actual = _subwayStationRepository.GetAllSubwayStations();

            // then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Where(e => e.IsDeleted), actual.Where(a => a.IsDeleted));
        }

        [Test]
        public void GetAllSubwayStationsWhereSitterExistTest()
        {
            //given
            var expected = _context.SubwayStations.ToList();

            //when
            var actual = _subwayStationRepository.GetAllSubwayStationsWhereSitterExist();

            //then
            Assert.AreNotEqual(expected, actual);
            Assert.That(actual[0].IsDeleted is false);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetSubwayStationByIdTest(int id)
        {
            //given
            var expected = _context.SubwayStations.Find(id);

            //when
            var actual = _subwayStationRepository.GetSubwayStationById(id);

            //then
            Assert.AreEqual(expected, actual);
            Assert.That(actual.IsDeleted == false | true);
        }

        [Test]
        public void AddSubwayStationTest()
        {
            //given
            var expected = SubwayStationTestCaseSourse.GetSubwayStation();

            //when
            _subwayStationRepository.AddSubwayStation(expected);

            var actual = _context.SubwayStations.FirstOrDefault(a => a.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateSubwayStationTest()
        {
            //given
            var subwayStation = SubwayStationTestCaseSourse.GetSubwayStation();
            _context.SubwayStations.Add(subwayStation);

            _context.SaveChanges();

            var expected = new SubwayStation()
            {
                Id = subwayStation.Id,
                Name = "ChangeName",
                IsDeleted = subwayStation.IsDeleted,
                Sitters = new List<Sitter>()
            };

            //when
            _subwayStationRepository.UpdateSubwayStation(expected);

            var actual = _context.SubwayStations.First(a => a.Id == subwayStation.Id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Sitters, actual.Sitters);
        }

        [Test]
        public void UpdateIsDeleteSubwayStationTest()
        {
            //given
            var subwayStation = SubwayStationTestCaseSourse.GetSubwayStation();

            //when
            _subwayStationRepository.UpdateSubwayStation(subwayStation, true);

            //then
            Assert.AreEqual(subwayStation.IsDeleted, true);
        }

        [Test]
        public void RestoreSubwayStationTest()
        {
            //given
            var subwayStation = SubwayStationTestCaseSourse.GetSubwayStation();

            //when
            _subwayStationRepository.RestoreSubwayStation(subwayStation, false);

            //then
            Assert.AreEqual(subwayStation.IsDeleted, false);
        }
    }
}
