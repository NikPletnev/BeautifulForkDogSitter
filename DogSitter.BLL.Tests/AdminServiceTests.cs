﻿using AutoMapper;
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
        private readonly Mock<IAdminRepository> _adminRepositoryMock;
        private readonly IMapper _mapper;
        private readonly AdminService _service;

        public AdminServiceTests()
        {
            _adminRepositoryMock = new Mock<IAdminRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new AdminService(_adminRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(UpdateAdminTestCaseSource))]
        public void UpdateAdminTest(int id, Admin entity, AdminModel model)
        {
            //given
            _adminRepositoryMock.Setup(x => x.UpdateAdmin(entity)).Verifiable();
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(entity);
            //when
            _service.UpdateAdmin(id, model);
            //then
            _adminRepositoryMock.Verify();
            _adminRepositoryMock.Verify(x => x.GetAdminById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(99)]
        public void UpdateAdminTest_WhenAdminNotFound_ShouldThrowServiceNotFoundExeption(int id)
        {
            //given
            AdminModel admin = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
            };
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(It.IsAny<Admin>());
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.UpdateAdmin(id, admin));
        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(99)]
        public void UpdateAdminTest_WhenNotEnoughDataAboutAdmin_ShouldThrowServiceNotEnoughDataExeption(int id)
        {
            //given
            AdminModel admin = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "",
                Password = "",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
            };
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(It.IsAny<Admin>());
            //when
            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.UpdateAdmin(id, admin));
        }

        [TestCaseSource(typeof(AddAdminTestCaseSource))]
        public void AddAdminTest(AdminModel admin)
        {
            //given
            _adminRepositoryMock.Setup(x => x.AddAdmin(It.IsAny<Admin>())).Verifiable();
            //when
            _service.AddAdmin(admin);
            //then
            _adminRepositoryMock.Verify();
        }

        [Test]
        public void AddAdminTest_WhenNotEnoughDataAboutAdmin_ShouldThrowServiceNotEnoughDataExeption()
        {
            //given
            _adminRepositoryMock.Setup(x => x.AddAdmin(It.IsAny<Admin>()));
            AdminModel admin = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "",
                Password = "",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
            };
            //when

            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.AddAdmin(admin));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(138)]
        public void DeleteAdminTest(int id)
        {
            //given
            Admin admin = new Admin()
            {
                Id = id,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
                IsDeleted = false
            };

            _adminRepositoryMock.Setup(x => x.UpdateAdmin(admin.Id, true)).Verifiable();
            _adminRepositoryMock.Setup(x => x.GetAdminById(admin.Id)).Returns(admin).Verifiable();
            //when
            _service.DeleteAdmin(id);
            //then
            _adminRepositoryMock.VerifyAll();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(138)]
        public void RestoreAdminTest(int id)
        {
            //given
            Admin admin = new Admin()
            {
                Id = id,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
                IsDeleted = false
            };

            _adminRepositoryMock.Setup(x => x.UpdateAdmin(admin.Id, false)).Verifiable();
            _adminRepositoryMock.Setup(x => x.GetAdminById(admin.Id)).Returns(admin).Verifiable();
            //when
            _service.RestoreAdmin(id);
            //then
            _adminRepositoryMock.VerifyAll();
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(11)]
        public void DeleteOrRestoreAdminTest_WhenAdminNotFound_ShouldThrowServiceNotFoundExeption(int id)
        {
            //given
            Admin admin = new Admin()
            {
                Id = id,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = DAL.Enums.ContactType.mail } },
                IsDeleted = false
            };

            _adminRepositoryMock.Setup(x => x.UpdateAdmin(admin.Id, true)).Verifiable();
            _adminRepositoryMock.Setup(x => x.UpdateAdmin(admin.Id, false)).Verifiable();
            _adminRepositoryMock.Setup(x => x.GetAdminById(admin.Id));
            //when

            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.DeleteAdmin(id));
            Assert.Throws<ServiceNotFoundExeption>(() => _service.RestoreAdmin(id));
        }

        [TestCaseSource(typeof(GetAdminByIdTestCaseSource))]
        public void GetAdminByIdTest(int id, Admin admin)
        {
            //given
            _adminRepositoryMock.Setup(x => x.GetAdminById(id)).Returns(admin).Verifiable();
            //when
            //then
            var actual = _service.GetAdminById(id);
            Assert.AreEqual(actual, new AdminModel()
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Password = admin.Password,
                Id = admin.Id,
                Contacts = new List<ContactModel>() { }
            });
            _adminRepositoryMock.Verify();
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(11)]
        public void GetAdminByIdTest_WhenAdminNotFound_ShouldThrowServiceNotFoundExeption(int id)
        {
            //given
            _adminRepositoryMock.Setup(x => x.GetAdminById(id));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.GetAdminById(id));
        }

        [TestCaseSource(typeof(GetAllAdminsTestCaseSource))]
        public void GetAllAdminsTest(List<Admin> admins, List<AdminModel> expected) 
        {
            // это не проходит и я искренне не понимаю как проверять контакты, если в одном месте это лист, а в другой айколекшн
            //given
            _adminRepositoryMock.Setup(x => x.GetAllAdmins()).Returns(admins).Verifiable();
            //when
            var actual = _service.GetAllAdmins();
            //then
            Assert.AreEqual(actual, expected);
            _adminRepositoryMock.Verify();
        }

        [TestCaseSource(typeof(GetAdminByIdTestCaseSource))]
        public void GetAdminByIdWithContactById(int id, Admin admin)
        {
            //given
            _adminRepositoryMock.Setup(x => x.GetAdminByIdWithContacts(id)).Returns(admin).Verifiable();
            //when
            var actual = _service.GetAdminWithContacts(id);
            //then
            Assert.AreEqual(actual, new AdminModel()
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Password = admin.Password,
                Id = admin.Id,
                Contacts = new List<ContactModel>() { }
            });
            _adminRepositoryMock.Verify();
        }

        [TestCaseSource(typeof(GetAllAdminsTestCaseSource))]
        public void GetAllAdminsWithContactTest(List<Admin> admins, List<AdminModel> expected)
        {
            // это не проходит и я искренне не понимаю как проверять контакты, если в одном месте это лист, а в другой айколекшн
            //given
            _adminRepositoryMock.Setup(x => x.GetAllAdminWithContacts()).Returns(admins).Verifiable();
            //when
            //then
            var actual = _service.GetAllAdminsWithContacts();
            Assert.AreEqual(actual, expected);
            _adminRepositoryMock.Verify();
        }
    }
}
