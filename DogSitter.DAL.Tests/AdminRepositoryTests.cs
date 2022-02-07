using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class AdminRepositoryTests
    {
        private DogSitterContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("AdminTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Test]
        public void GetAllAdminsTest()
        {
            //given
            List<Admin> admins = new List<Admin>() {
              new Admin()
                {
                 FirstName = "Иван",
                 LastName = "Иванов",
                 Password = "VANYA1234",
                 IsDeleted = false
                },
              new Admin()
                {
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
                 IsDeleted = false
                },
              new Admin()
                {
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
                 IsDeleted = true
                }
            };

            _context.Admins.AddRange(admins);
            _context.SaveChanges();

            var expected = new List<Admin>() {
              new Admin()
              {
                 Id = 1,
                 FirstName = "Иван",
                 LastName = "Иванов",
                 Password = "VANYA1234",
              },
              new Admin()
              {
                 Id = 2,
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
              }
            };

            var rep = new AdminRepository(_context);

            //when
            var actual = rep.GetAllAdmins();

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAdminByIdTest()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin()
                {
                 FirstName = "Иван",
                 LastName = "Иванов",
                 Password = "VANYA1234",
                 IsDeleted = false
                },
              new Admin()
                {
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
                 IsDeleted = true
                }
            };
            _context.Admins.AddRange(admins);
            _context.SaveChanges();

            var expected = new Admin()
            {
                Id = 2,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
            };

            var rep = new AdminRepository(_context);

            var actual = rep.GetAdminById(2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAdminTest()
        {
            var admin = new Admin()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
            };

            var expected = new Admin()
            {
                Id = 1,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
            };

            var rep = new AdminRepository(_context);
            rep.AddAdmin(admin);

            var actual = _context.Admins.FirstOrDefault(z => z.Id == expected.Id);

            Assert.AreEqual(actual.IsDeleted, false);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeleteAdminTest()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin()
                {
                 FirstName = "Иван",
                 LastName = "Иванов",
                 Password = "VANYA1234",
                 IsDeleted = false

                },
              new Admin()
                {
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
                 IsDeleted = false
                }
            };
            _context.Admins.AddRange(admins);
            _context.SaveChanges();

            var expected = new Admin()
            {
                Id = 2,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                IsDeleted = true
            };

            var rep = new AdminRepository(_context);

            rep.UpdateAdmin(2, true);
            var actual = _context.Admins.FirstOrDefault(z => z.Id == 2);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateAdminTest()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin()
                {
                 FirstName = "Иван",
                 LastName = "Иванов",
                 Password = "VANYA1234",
                 IsDeleted = false

                },
              new Admin()
                {
                 FirstName = "Иван2",
                 LastName = "Иванов2",
                 Password = "2VANYA1234",
                 IsDeleted = false
                }
            };
            _context.Admins.AddRange(admins);
            _context.SaveChanges();

            var newAdmin = new Admin()
            {
                Id = 2,
                FirstName = "Иван222",
                LastName = "Иванов222",
                Password = "2VANYA123422",
                IsDeleted = false
            };

            var expected = new Admin()
            {
                Id = 2,
                FirstName = "Иван222",
                LastName = "Иванов222",
                Password = "2VANYA123422",
                IsDeleted = false
            };

            var rep = new AdminRepository(_context);

            rep.UpdateAdmin(newAdmin);

            var actual = _context.Admins.FirstOrDefault(z => z.Id == 2);

            Assert.AreEqual(expected, actual);


        }

    }
}