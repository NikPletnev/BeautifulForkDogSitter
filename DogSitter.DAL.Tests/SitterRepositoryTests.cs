using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests
{
    public class SitterRepositoryTests
    {
        private DogSitterContext _context;
        private SitterRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("SitterTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new SitterRepository(_context);
        }

        [TestCaseSource(typeof(EditStateProfileSitterByIdTestCaseSource))]
        public void ConfirmProfileSitterByIdTest(int id, bool verify, List<Sitter> sitters)
        {
            //given
            _context.AddRange(sitters);
            _context.SaveChanges();

            //when
            _rep.EditStateProfileSitterById(id, verify);
            var actual = _context.Sitters.FirstOrDefault(x => x.Id == id).Verified;

            //then
            Assert.AreEqual(actual, verify);
        }
    }
}
