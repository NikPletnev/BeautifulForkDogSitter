using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

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
              new Contact() { Id = 1, Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false },
              new Contact() { Id = 2, Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false }
            };

            //when
            var actual = _rep.GetAllContacts();

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetContactByValueTestCaseSource))]
        public void GetContactByValueTest(List<Admin> admins, string value, Contact expectedContact, Admin expectedAdmin)
        {
            //given           
            _context.Admins.AddRange(admins);
            _context.SaveChanges();
        }

        [TestCaseSource(typeof(GetAllContactsByCustomerIdTestCaseSource))]
        public void GetAllContactsByCustomerIdTest(int id, List<Customer> customers, List<Contact> expected)
        {
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
            var actual = _rep.GetAllContactsByCustomerId(id);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllContactsBySitterIdTestCaseSource))]
        public void GetAllContactsBySitterIdTest(int id, List<Sitter> sitters, List<Contact> expected)
        {
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();
            var actual = _rep.GetAllContactsBySitterId(id);
            Assert.AreEqual(expected, actual);
        }

    }
}
