using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

            var subwayStations = SubwayStationTestCaseSourse.GetSubwayStations();
            _context.SubwayStations.AddRange(subwayStations);

            _context.SaveChanges();

            _context = new DogSitterContext(options);

            _subwayStationRepository = new SubwayStationRepository(_context);
        }

        [Test]
        public void GetAllSubwayStationsTest()
        {
            // given
            var expected = _context.SubwayStations.Where(ss => ss.IsDeleted).Select(ss => ss.Id).ToList();

            // when
            var actual = _subwayStationRepository.GetAllSubwayStations();

            // then
            Assert.True(actual.All(ss => !expected.Contains(ss.Id)));
            Assert.True(actual.All(a => !a.IsDeleted));
        }

        [Test]
        public void GetAllSubwayStationsWhereSitterExistTest()
        {
            //given
            var expected = _context.SubwayStations
                .Where(ss => ss.Sitters.All(s => s.IsDeleted)).Select(ss => ss.Id).ToList();

            //when
            var actual = _subwayStationRepository.GetAllSubwayStationsWhereSitterExist();

            //then
            Assert.True(actual.All(ss => !expected.Contains(ss.Id)));
            Assert.True(actual.All(a => !a.IsDeleted));
            Assert.True(actual.Select(a => a.Sitters).All(s => s is null));
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

            var updatedSubwayStation = new SubwayStation()
            {
                Id = subwayStation.Id,
                Name = "ChangeName",
                IsDeleted = subwayStation.IsDeleted,
                Sitters = new List<Sitter>()
            };

            //when
            _subwayStationRepository.UpdateSubwayStation(subwayStation, updatedSubwayStation);
            var actual = _context.SubwayStations.First(a => a.Id == updatedSubwayStation.Id);

            //then
            Assert.AreEqual(subwayStation.Id, actual.Id);
            Assert.AreEqual(updatedSubwayStation.Name, actual.Name);
            Assert.AreEqual(subwayStation.Sitters, actual.Sitters);
            Assert.AreEqual(subwayStation.IsDeleted, actual.IsDeleted);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdateOrDeleteSubwayStationTest(bool isDeleted)
        {
            //given
            var subwayStation = SubwayStationTestCaseSourse.GetSubwayStation();

            //when
            _subwayStationRepository.UpdateOrDeleteSubwayStation(subwayStation, isDeleted);

            //then
            Assert.AreEqual(subwayStation.IsDeleted, isDeleted);
        }
    }
}
