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
        private SitterRepository _sitterRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("SitterTest")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _sitterRepository = new SitterRepository(_context);
        }


        [TestCaseSource(typeof(SitterLoginTestCaseSource))]
        public void LoginTest(List<Sitter> sitters, Contact contact, string pass, Sitter expected)
        {
            //given
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();
            var findedSitter = _context.Sitters.FirstOrDefault(x => x.Id == 1);
            contact.Sitter = findedSitter;
            _context.SaveChanges();
            //when
            var actual = _sitterRepository.Login(contact, pass);
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(EditStateProfileSitterByIdTestCaseSource))]
        public void ConfirmProfileSitterByIdTest(int id, bool verify, List<Sitter> sitters)
        {
            //given
            _context.AddRange(sitters);
            _context.SaveChanges();

            //when
            _sitterRepository.EditProfileStateBySitterId(id, verify);
            var actual = _context.Sitters.FirstOrDefault(x => x.Id == id).Verified;

            //then
            Assert.AreEqual(actual, verify);
        }

        [TestCaseSource(typeof(GetAllSittersByServiceIdTestCaseSource))]
        public void GetAllSittersByServiceIdTest(int id, Serviсe service, List<Sitter> expected)
        {
            //given
            _context.Services.AddRange(service);
            _context.SaveChanges();

            //when
            var actual = _sitterRepository.GetAllSitterByServiceId(id);

            //then
            Assert.AreEqual(expected, actual);
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
