using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
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

        [TestCaseSource(typeof(ContactTestCaseSource))]
        public void GetAllContactsTest(List<Contact> contacts)
        {
            //given
            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();

            var expected = new List<Contact>() {
              new Contact() { Id = 1, Value = "89871234567", ContactType = ContactType.phone, IsDeleted = false },
              new Contact() { Id = 2, Value = "@qwerty", ContactType = ContactType.mail, IsDeleted = false }
            };

            //when
            var actual = _rep.GetAllContacts();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ContactTestCaseSource))]
        public void GetContactByIdTest(List<Contact> contacts)
        {
            //given          
            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();

            var expected = new Contact() { Id = 3, Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = true };

            //when
            var actual = _rep.GetContactById(3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddContactTest()
        {
            //given
            var contact = new Contact() { Value = "qwerty123@icloud.com", ContactType = (ContactType)2 };
            var expected = new Contact() { Id = 1, Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = false };

            //when
            _rep.AddContact(contact);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 1);

            //then
            Assert.AreEqual(expected, actual);


        }

        [TestCaseSource(typeof(ContactTestCaseSource))]
        public void DeleteContactTest(List<Contact> contacts)
        {
            //given
            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();

            var expected = new Contact() { Id = 3, Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = true };

            //when
            _rep.UpdateContact(3, true);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ContactTestCaseSource))]
        public void UpdateContactTest(List<Contact> contacts)
        {
            //given

            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();

            var newContact = new Contact() { Id = 3, Value = "NewNewNew@icloud.com", ContactType = (ContactType)2 };

            var expected = new Contact() { Id = 3, Value = "NewNewNew@icloud.com", ContactType = ContactType.mail, IsDeleted = true };

            //when
            _rep.UpdateContact(newContact);
            var actual = _context.Contacts.FirstOrDefault(z => z.Id == 3);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetContactByValueTestCaseSource))]
        public void GetContactByValueTest(List <Admin> admins, string value, Contact expectedContact, Admin expectedAdmin)
        {
            //given           
            _context.Admins.AddRange(admins);
            _context.SaveChanges();

            var foundAdmin = _context.Admins.FirstOrDefault(x => x.Id == 2);
            var foundContact = _context.Contacts.FirstOrDefault(x => x.Id == 2);
            foundContact.Admin = foundAdmin;
            _context.SaveChanges();

            //when
            var actual = _rep.GetContactByValue(value);

            //then
            Assert.AreEqual(expectedContact, actual);
            Assert.AreEqual(expectedAdmin, actual.Admin);
        }
    }
}
