using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class Tests
    {
        public class AdminRepositoryTests
        {
            private DogSitterContext _context;
            private AdminRepository _rep;

            [SetUp]
            public void Setup()
            {
                var options = new DbContextOptionsBuilder<DogSitterContext>()
                    .UseInMemoryDatabase("AdminTestDB")
                    .Options;

                _context = new DogSitterContext(options);

                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                _rep = new AdminRepository(_context);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void GetAllAdminsTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var expected = new List<Admin>() {
                new Admin() { Id = 1, FirstName = "Иван", LastName = "Иванов",  Password = "VANYA1234" },
                new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234"}
                };

                //when
                var actual = _rep.GetAllAdmins();

                //then
                Assert.AreEqual(expected, actual);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void GetAllAdminWithContactsTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var expected = new List<Admin>() {
                new Admin() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234",
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = Enums.ContactType.phone} } ,
                  IsDeleted = false} ,
                new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = Enums.ContactType.mail} },
                  IsDeleted = false }
                };

                //when
                var actual = _rep.GetAllAdminWithContacts();

                //then
                CollectionAssert.AreEqual(expected, actual);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void GetAdminByIdTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var expected = new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = false };

                //when
                var actual = _rep.GetAdminById(2);

                //then
                Assert.AreEqual(expected, actual);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void GetAdminByIdWithContactsTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var expected = new Admin()
                {
                    Id = 2,
                    FirstName = "Иван2",
                    LastName = "Иванов2",
                    Password = "2VANYA1234",
                    Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = Enums.ContactType.mail } },
                    IsDeleted = false
                };

                //when
                var actual = _rep.GetAdminByIdWithContacts(2);

                //then
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void AddAdminTest()
            {
                //given
                var admin = new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234" };
                var expected = new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = false };

                //when
                _rep.AddAdmin(admin);

                var actual = _context.Admins.FirstOrDefault(z => z.Id == expected.Id);

                //then
                Assert.AreEqual(expected, actual);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void DeleteAdminTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var expected = new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true };

                //when
                _rep.UpdateAdmin(2, true);
                var actual = _context.Admins.FirstOrDefault(z => z.Id == 2);

                //then
                Assert.AreEqual(expected, actual);
            }

            [TestCaseSource(typeof(AdminTestCaseSource))]
            public void UpdateAdminTest(List<Admin> admins)
            {
                //given
                _context.Admins.AddRange(admins);
                _context.SaveChanges();

                var newAdmin = new Admin() { Id = 2, FirstName = "Иван222", LastName = "Иванов22", Password = "4321VANYA1234" };

                var expected = new Admin() { Id = 2, FirstName = "Иван222", LastName = "Иванов22", Password = "4321VANYA1234", IsDeleted = false };

                //when
                _rep.UpdateAdmin(newAdmin);

                var actual = _context.Admins.FirstOrDefault(z => z.Id == 2);

                //then
                Assert.AreEqual(expected, actual);
            }



        }
    }
}