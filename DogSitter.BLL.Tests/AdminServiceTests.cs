using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class AdminServiceTests
    {
        private Mock<IAdminRepository> _adminRepositoryMock;
        private IMapper _mapper;
        private AdminService _service;

        [SetUp]
        public void Setup()
        {
            _adminRepositoryMock = new Mock<IAdminRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new AdminService(_adminRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(UpdateAdminTestCaseSource))]
        public void UpdateAdminTest(int id, Admin entity, AdminModel model)
        {
            //given
            _adminRepositoryMock.Setup(x => x.UpdateAdmin(It.IsAny<Admin>(), entity)).Verifiable();
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(entity).Verifiable();
            //when
            _service.UpdateAdmin(id, model);
            //then
            _adminRepositoryMock.Verify(x => x.GetAdminById(id), Times.Once);
            _adminRepositoryMock.Verify(x => x.UpdateAdmin(It.IsAny<Admin>(), entity), Times.Once);
        }

        [TestCase(99)]
        public void UpdateAdminTest_WhenAdminNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            AdminModel admin = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<ContactModel> { new ContactModel
                { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.Mail } },
            };
            _adminRepositoryMock.Setup(x => x.GetAdminById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.UpdateAdmin(id, admin));
            _adminRepositoryMock.Verify(x => x.UpdateAdmin(It.IsAny<Admin>(), It.IsAny<Admin>()), Times.Never);
            _adminRepositoryMock.Verify(x => x.GetAdminById(id), Times.Once);
        }

        [TestCase(99)]
        public void UpdateAdminTest_WhenNotEnoughDataAboutAdmin_ShouldThrowServiceNotEnoughDataExeption(int id)
        {
            //given
            AdminModel admin = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "",
                Password = "",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.Mail } },
            };
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(It.IsAny<Admin>());
            //when
            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.UpdateAdmin(id, admin));
            _adminRepositoryMock.Verify(x => x.UpdateAdmin(It.IsAny<Admin>(), It.IsAny<Admin>()), Times.Never);
            _adminRepositoryMock.Verify(x => x.GetAdminById(id), Times.Never);
        }

        [TestCaseSource(typeof(GetAllAdminsWithContactsTestCaseSource))]
        public void GetAllAdminsWithContactTest(List<Admin> admins, List<AdminModel> expected)
        {
            //given
            _adminRepositoryMock.Setup(x => x.GetAllAdminWithContacts()).Returns(admins);
            //when
            //then
            var actual = _service.GetAllAdminsWithContacts();
            CollectionAssert.AreEqual(actual, expected);
            _adminRepositoryMock.Verify(x => x.GetAllAdminWithContacts(), Times.Once);
        }
    }
}
