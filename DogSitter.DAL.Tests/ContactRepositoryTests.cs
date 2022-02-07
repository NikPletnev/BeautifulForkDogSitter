using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class ContactRepositoryTests
    {
        private DogSitterContext _context;
        private ContactRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("ContactTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new ContactRepository(_context);
        }

        [Test]
        public void GetAllContactsTest()
        {
            //given
            List<Contact> Contacts = new List<Contact>() {
              new Contact()
                {
                 Value = "89871234567",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "@qwerty",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "qwerty123@icloud.com",
                 IsDeleted = true
                }
            };

            _context.Contacts.AddRange(Contacts);
            _context.SaveChanges();

            var expected = new List<Contact>() {
              new Contact()
                {
                 Id = 1,
                 Value = "89871234567",
                 IsDeleted = false
                },
              new Contact()
                {
                  Id = 2,
                 Value = "@qwerty",
                 IsDeleted = false
                },
            };

            //when
            var actual = _rep.GetAllContacts();

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetContactByIdTest()
        {
            //given
            List<Contact> Contacts = new List<Contact>() {
              new Contact()
                {
                 Value = "89871234567",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "@qwerty",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "qwerty123@icloud.com",
                 IsDeleted = true
                }
            };

            _context.Contacts.AddRange(Contacts);
            _context.SaveChanges();

            var expected =
              new Contact()
              {
                  Id = 3,
                  Value = "qwerty123@icloud.com",
                  IsDeleted = true
              };

            //when
            var actual = _rep.GetContactById(3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddContactTest()
        {
            //given
            var contact =
              new Contact()
              {
                  Value = "qwerty123@icloud.com",
              };

            var expected =
              new Contact()
              {
                  Id = 1,
                  Value = "qwerty123@icloud.com",
                  IsDeleted = false
              };

            //when
            _rep.AddContact(contact);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(expected, actual);


        }

        [Test]
        public void DeleteContactTest()
        {
            //given
            List<Contact> Contacts = new List<Contact>() {
              new Contact()
                {
                 Value = "89871234567",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "@qwerty",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "qwerty123@icloud.com",
                 IsDeleted = false
                }
            };

            _context.Contacts.AddRange(Contacts);
            _context.SaveChanges();

            var expected =
              new Contact()
              {
                  Id = 3,
                  Value = "qwerty123@icloud.com",
                  IsDeleted = true
              };

            //when
            _rep.UpdateContact(3, true);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateContactTest()
        {
            //given
            List<Contact> Contacts = new List<Contact>() {
              new Contact()
                {
                 Value = "89871234567",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "@qwerty",
                 IsDeleted = false
                },
              new Contact()
                {
                 Value = "qwerty123@icloud.com",
                 IsDeleted = false
                }
            };

            _context.Contacts.AddRange(Contacts);
            _context.SaveChanges();

            var newContact =
                new Contact()
                {
                    Id = 3,
                    Value = "NewNewNew@icloud.com",
                };

            var expected =
              new Contact()
              {
                  Id = 3,
                  Value = "NewNewNew@icloud.com",
                  IsDeleted = false
              };

            //when
            _rep.UpdateContact(newContact);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
