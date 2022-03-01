using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
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
            _service = new AuthService(_contactRepositoryMock.Object, _userRepositoryMock.Object, _map);
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
            var password = "111111";
            User user = new User()
            {
                Id = 1,
                Password = "12345",
                FirstName = "FirstName1",
                LastName = "LastName1",
                IsDeleted = false
            };
            _userRepositoryMock.Setup(m => m.ChangeUserPassword(password, user));
            _userRepositoryMock.Setup(m => m.GetUserById(user.Id)).Returns(user);

            //when
            _service.ChangeUserPassword(user.Id, password);

            //then
            _userRepositoryMock.Verify(m => m.ChangeUserPassword(It.IsAny<string>(), user), Times.Once);
        }

        [Test]
        public void ChangeUserPasswordNegativeTest()
        {
            _userRepositoryMock.Setup(m => m.ChangeUserPassword(It.IsAny<string>(), It.IsAny<User>()));
            _userRepositoryMock.Setup(m => m.GetUserById(It.IsAny<int>())).Returns((User)null);

            Assert.Throws<EntityNotFoundException>(() =>
            _service.ChangeUserPassword(It.IsAny<int>(), It.IsAny<string>()));
        }
    }
}