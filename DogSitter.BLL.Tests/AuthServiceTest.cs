using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
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
            _map = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new AuthService(_contactRepositoryMock.Object, _adminRepositoryMock.Object, _customerRepositoryMock.Object, _sitterRepositoryMock.Object, _map);

        }

        [TestCaseSource(typeof(LoginAdminTestCaseSource))]
        public void LoginAdminTestMustValidateToken(Admin admin, Contact contact, string password)
        {
            //given
            _adminRepositoryMock.Setup(a => a.Login(contact, password)).Returns(admin);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when
            var token = _service.LoginAdmin(contact.Value, password);

            //then
            Assert.IsNotNull(token);
            Assert.IsTrue(ValidateToken(token));
        }

        [TestCaseSource(typeof(LoginCustomerTestCaseSource))]
        public void LoginCustomerTestMustValidateToken(Customer customer, Contact contact, string password)
        {
            //given
            _customerRepositoryMock.Setup(a => a.Login(contact, password)).Returns(customer);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when
            var token = _service.LoginCustomer(contact.Value, password);

            //then
            Assert.IsNotNull(token);
            Assert.IsTrue(ValidateToken(token));
        }

        [TestCaseSource(typeof(LoginSitterTestCaseSource))]
        public void LoginSitterTestMustValidateToken(Sitter sitter, Contact contact, string password)
        {
            //given
            _sitterRepositoryMock.Setup(a => a.Login(contact, password)).Returns(sitter);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);

            //when
            var token = _service.LoginSitter(contact.Value, password);

            //then
            Assert.IsNotNull(token);
            Assert.IsTrue(ValidateToken(token));
        }

        [TestCaseSource(typeof(LoginAdminTestCaseSource))]
        public void LoginAdminTestServiceNotFoundExeptionAdminNotFound(Admin admin, Contact contact, string password)
        {
            //given
            Admin nullAdmin = null;
            _adminRepositoryMock.Setup(a => a.Login(contact, password)).Returns(nullAdmin);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);
            string expectedMessage = "Admin not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginAdmin(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));

        }


        [TestCaseSource(typeof(LoginAdminTestCaseSource))]
        public void LoginAdminTestServiceNotFoundExeptionContactNotFound(Admin admin, Contact contact, string password)
        {
            //given
            Contact nullContact = null;
            _adminRepositoryMock.Setup(a => a.Login(contact, password)).Returns(admin);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(nullContact);
            string expectedMessage = "Contact not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginSitter(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(LoginCustomerTestCaseSource))]
        public void LoginCustomerTestServiceNotFoundExeptionCustomerNotFound(Customer customer, Contact contact, string password)
        {
            //given
            Customer nullCustomer = null;
            _customerRepositoryMock.Setup(a => a.Login(contact, password)).Returns(nullCustomer);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);
            string expectedMessage = "Customer not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginCustomer(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));

        }


        [TestCaseSource(typeof(LoginCustomerTestCaseSource))]
        public void LoginCustomerTestServiceNotFoundExeptionContactNotFound(Customer customer, Contact contact, string password)
        {
            //given
            Contact nullContact = null;
            _customerRepositoryMock.Setup(a => a.Login(contact, password)).Returns(customer);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(nullContact);
            string expectedMessage = "Contact not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginCustomer(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [TestCaseSource(typeof(LoginSitterTestCaseSource))]
        public void LoginSitterTestServiceNotFoundExeptionSitterNotFound(Sitter sitter, Contact contact, string password)
        {
            //given
            Sitter nullSitter = null;
            _sitterRepositoryMock.Setup(a => a.Login(contact, password)).Returns(nullSitter);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(contact);
            string expectedMessage = "Sitter not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginSitter(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));

        }


        [TestCaseSource(typeof(LoginSitterTestCaseSource))]
        public void LoginSitterTestServiceNotFoundExeptionContactNotFound(Sitter sitter, Contact contact, string password)
        {
            //given
            Contact nullContact = null;
            _sitterRepositoryMock.Setup(a => a.Login(contact, password)).Returns(sitter);
            _contactRepositoryMock.Setup(a => a.GetContactByValue(contact.Value)).Returns(nullContact);
            string expectedMessage = "Contact not found";

            //when


            //then
            ServiceNotFoundExeption ex = Assert.Throws<ServiceNotFoundExeption>(() => _service.LoginSitter(contact.Value, password));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
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