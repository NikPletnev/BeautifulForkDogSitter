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
using System.IdentityModel.Tokens.Jwt;

namespace DogSitter.BLL.Tests
{
    public class AuthServiceTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private Mock<ISitterRepository> _sitterRepositoryMock;
        private Mock<IContactRepository> _contactRepositoryMock;
        private IMapper _map;
        private Mock<IAdminRepository> _adminRepositoryMock;
        private AuthService _service;


        [SetUp]
        public void Setup()
        {
            _adminRepositoryMock = new Mock<IAdminRepository>();
            _contactRepositoryMock = new Mock<IContactRepository>();
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _map = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new AuthService(_contactRepositoryMock.Object, _adminRepositoryMock.Object, _customerRepositoryMock.Object, _sitterRepositoryMock.Object, _map);

        }

        [TestCaseSource(typeof(LoginAdminTestCaseSource))]
        public void GetUserForLoginTestMustReturnAdmin(Admin admin, UserModel expected, Contact contact, string password)
        {
            //given
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when
            var result = _service.GetUserForLogin(contact.Value, password);

            //then

            Assert.AreEqual(expected, result);
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
    }
}