using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class UserRepisitoryTests
    {
        private DogSitterContext _context;
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
            .UseInMemoryDatabase(databaseName: "WorkTimeTests")
            .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureCreated();
            _context.Database.EnsureDeleted();

            _userRepository = new UserRepository(_context);

            var users = UserTestMock.GetUsers();
            _context.Users.AddRange(users);

            _context.SaveChanges();
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetUserByIdTest(int id)
        {
            //given
            var expected = _context.Users.Find(id);

            //when
            var actual = _userRepository.GetUserById(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ChangeUserPasswordTest(int id)
        {
            //given
            var user = _context.Users.Find(id);
            var newPassword = "11111";

            //when
            _userRepository.ChangeUserPassword(newPassword, user);
            _context.Users.FirstOrDefault(a => a.Id == user.Id);

            //then
            Assert.AreEqual(newPassword, user.Password);
        }
    }
}
