using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class ContactTypeRepositoryTests
    {
        private DogSitterContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("ContactTypeTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public void GetAllContactTypesTest()
        {
            //given
            List<ContactType> ContactTypes = new List<ContactType>() {
              new ContactType()
                {
                 Name = "телефон",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "телеграмм",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "почта",
                 IsDeleted = true
                }
            };

            _context.ContactTypes.AddRange(ContactTypes);
            _context.SaveChanges();

            var expected = new List<ContactType>() {
              new ContactType()
                {
                 Id = 1,
                 Name = "телефон",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Id = 2,
                 Name = "телеграмм",
                 IsDeleted = false
                },
            };

            var rep = new ContactTypeRepository(_context);

            //when
            var actual = rep.GetAllContactTypes();

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetContactTypeByIdTest()
        {
            //given
            List<ContactType> ContactTypes = new List<ContactType>() {
              new ContactType()
                {
                 Name = "телефон",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "телеграмм",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "почта",
                 IsDeleted = true
                }
            };

            _context.ContactTypes.AddRange(ContactTypes);
            _context.SaveChanges();

            var expected =
              new ContactType()
              {
                  Id = 3,
                  Name = "почта",
                  IsDeleted = true
              };

            var rep = new ContactTypeRepository(_context);

            //when
            var actual = rep.GetContactTypeById(3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddContactTypeTest()
        {
            //given
            var contactType =
              new ContactType()
              {
                  Name = "телеграмм"
              };

            var expected =
              new ContactType()
              {
                  Id = 1,
                  Name = "телеграмм",
                  IsDeleted = false
              };

            var rep = new ContactTypeRepository(_context);

            //when
            rep.AddContactType(contactType);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(expected, actual);


        }

        [Test]
        public void DeleteContactTypeTest()
        {
            //given
            List<ContactType> ContactTypes = new List<ContactType>() {
               new ContactType()
                {
                 Name = "телефон",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "телеграмм",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "почта",
                 IsDeleted = true
                }
            };

            _context.ContactTypes.AddRange(ContactTypes);
            _context.SaveChanges();

            var expected =
              new ContactType()
              {
                  Id = 3,
                  Name = "почта",
                  IsDeleted = true
              };

            var rep = new ContactTypeRepository(_context);

            //when
            rep.UpdateContactType(3, true);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateContactTypeTest()
        {
            //given
            List<ContactType> ContactTypes = new List<ContactType>() {
              new ContactType()
                {
                 Name = "телефон",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "телеграмм",
                 IsDeleted = false
                },
              new ContactType()
                {
                 Name = "почта",
                 IsDeleted = false
                }
            };

            _context.ContactTypes.AddRange(ContactTypes);
            _context.SaveChanges();

            var newContactType =
                new ContactType()
                {
                    Id = 3,
                    Name = "вотс ап"
                };

            var expected =
              new ContactType()
              {
                  Id = 3,
                  Name = "вотс ап",
                  IsDeleted = false
              };

            var rep = new ContactTypeRepository(_context);

            //when
            rep.UpdateContactType(newContactType);
            var actual = _context.ContactTypes.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
