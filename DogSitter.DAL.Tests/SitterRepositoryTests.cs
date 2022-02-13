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
        //the rest of the tests for this entity are implemented in another branch
    }
}
