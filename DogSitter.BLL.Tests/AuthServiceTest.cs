using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using System.IdentityModel.Tokens.Jwt;

namespace DogSitter.BLL.Tests
{
    public class AuthServiceTests
    {
        private Mock<IContactRepository> _contactRepositoryMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private IMapper _map;
        private AuthService _service;

        [SetUp]
        public void Setup()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _map = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new AuthService(_contactRepositoryMock.Object, _userRepositoryMock.Object, _map, new Mock<ILogger<EmailSendller>>().Object);
        }

        [TestCaseSource(typeof(LoginAdminTestCaseSource))]
        public void GetUserForLoginTestMustReturnAdmin(UserModel expected, Contact contact, string password)
        {
            //given
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when
            var result = _service.GetUserForLogin(contact.Value, password);

            //then
            _contactRepositoryMock.Verify(m => m.GetContactByValue(contact.Value), Times.Once);
        }

        [TestCaseSource(typeof(GetTokenTestCaseSourse))]
        public void GetTokenTest_MustValidateToken(UserModel user)
        {
            //given 

            //when 
            var token = _service.GetToken(user);

            //then

            Assert.IsNotNull(token);
            Assert.IsTrue(ValidateToken(token));
        }

        [Test]
        public void LoginUserTest_WhenUserNotFound_ShouldThrowEntityNotFoundException()
        {
            //given
            Contact contact = new Contact()
            {
                Id = 1,
                Value = "12345678",
                ContactType = ContactType.Phone
            };

            string password = "1234567";

            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.GetUserForLogin(contact.Value, password));
        }

        [Test]
        public void LoginUserTest_WhenContactNotFound_ShouldThrowEntityNotFoundException()
        {
            //given
            Contact contact = new Contact()
            {
                Id = 1,
                Value = "12345678",
                ContactType = ContactType.Phone
            };

            string password = "1234567";

            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value));

            //when

            //then
            EntityNotFoundException ex = Assert.Throws<EntityNotFoundException>(() =>
            _service.GetUserForLogin(contact.Value, password));
        }

        private static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(authToken, GetValidationParameters(), out _);

            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = AuthOptions.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }

        [Test]
        public void ChangeUserPasswordTest()
        {
            //given
            var newPassword = "111111";
            var oldPassword = "12345";

            User user = new User()
            {
                Id = 1,
                Password = PasswordHash.HashPassword(oldPassword),
                FirstName = "FirstName1",
                LastName = "LastName1",
                IsDeleted = false
            };
            _userRepositoryMock.Setup(m => m.ChangeUserPassword(newPassword, user));
            _userRepositoryMock.Setup(m => m.GetUserById(user.Id)).Returns(user);

            //when
            _service.ChangeUserPassword(user.Id, newPassword, oldPassword);

            //then
            _userRepositoryMock.Verify(m => m.ChangeUserPassword(It.IsAny<string>(), user), Times.Once);
        }

        [Test]
        public void ChangeUserPasswordTest_WhenPasswordDonotMatch_ShouldThrowPasswordExeption()
        {
            var newPassword = "111111";
            var oldPassword = "12345";

            User user = new User()
            {
                Id = 1,
                Password = PasswordHash.HashPassword("54321"),
                FirstName = "FirstName1",
                LastName = "LastName1",
                IsDeleted = false
            };
            _userRepositoryMock.Setup(m => m.ChangeUserPassword(newPassword, user));
            _userRepositoryMock.Setup(m => m.GetUserById(user.Id)).Returns(user);

            Assert.Throws<PasswordException>(() =>
            _service.ChangeUserPassword(user.Id, newPassword, oldPassword));
        }

        [Test]
        public void ChangeUserPasswordTest_WhenUserWasNotFound_ShouldThrowEntityNotFoundException()
        {
            _userRepositoryMock.Setup(m => m.ChangeUserPassword(It.IsAny<string>(), It.IsAny<User>()));
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _service.ChangeUserPassword(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}