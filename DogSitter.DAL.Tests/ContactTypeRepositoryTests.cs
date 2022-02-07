using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class ContactTypeRepositoryTests
    {
        private DogSitterContext _context;
        private ContactTypeRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("ContactTypeTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new ContactTypeRepository(_context);
        }

        [TestCaseSource(typeof(ContactTypeTestCaseSource))]
        public void GetAllContactTypesTest(List <ContactType> contactTypes)
        {
            //given            
            _context.ContactTypes.AddRange(contactTypes);
            _context.SaveChanges();
            var expected = new List<ContactType>() {
            new ContactType() { Id = 1, Name = "телефон", IsDeleted = false, },
            new ContactType() { Id = 2, Name = "телеграмм", IsDeleted = false },
            };

            //when
            var actual = _rep.GetAllContactTypes();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ContactTypeTestCaseSource))]
        public void GetContactTypeByIdTest(List<ContactType> contactTypes)
        {
            //given
            _context.ContactTypes.AddRange(contactTypes);
            _context.SaveChanges();
            var expected = new ContactType() {Id = 3, Name = "почта", IsDeleted = true };

            //when
            var actual = _rep.GetContactTypeById(3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddContactTypeTest()
        {
            //given
            var contactType = new ContactType() { Name = "телефон" };
            var expected = new ContactType() { Id = 1, Name = "телефон", IsDeleted = false };

            //when
            _rep.AddContactType(contactType);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ContactTypeTestCaseSource))]
        public void DeleteContactTypeTest(List<ContactType> contactTypes)
        {
            //given
            _context.ContactTypes.AddRange(contactTypes);
            _context.SaveChanges();
            var expected = new ContactType() { Id = 2, Name = "телеграмм", IsDeleted = true };

            //when
            _rep.UpdateContactType(2, true);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ContactTypeTestCaseSource))]
        public void UpdateContactTypeTest(List<ContactType> contactTypes)
        {
            //given
            _context.ContactTypes.AddRange(contactTypes);
            _context.SaveChanges();
            var newContactType = new ContactType() { Id = 3, Name = "вотс ап" };
            var expected = new ContactType() { Id = 3, Name = "вотс ап", IsDeleted = true };

            //when
            _rep.UpdateContactType(newContactType);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
