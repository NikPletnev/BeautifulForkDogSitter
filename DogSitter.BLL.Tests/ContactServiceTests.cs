using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _ContactRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ContactService _service;

        public ContactServiceTests()
        {
            _ContactRepositoryMock = new Mock<IContactRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new ContactService(_ContactRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(UpdateContactTestCaseSource))]
        public void UpdateContactTest(int id, Contact entity, ContactModel model)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.UpdateContact(It.IsAny<Contact>())).Verifiable();
            _ContactRepositoryMock.Setup(x => x.GetContactById(id)).Returns(entity);
            //when

            //then
            Assert.DoesNotThrow(() => _service.UpdateContact(id, model));
            Assert.Pass();
            _ContactRepositoryMock.Verify();
            _ContactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(11)]
        [TestCase(100)]
        public void UpdateContactTest_WhenNotEnoughDataAboutContact_ShouldServiceNotEnoughDataExeption(int id)
        {
            //given
            var contactModel = new ContactModel() { Value = "" };

            //when

            //then

            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.UpdateContact(id, contactModel));
        }

        [TestCase(1)]
        [TestCase(11)]
        [TestCase(100)]
        public void UpdateContactTest_WhenContactNotFound_ShouldServiceNotFoundExeption(int id)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.UpdateContact(It.IsAny<Contact>()));
            _ContactRepositoryMock.Setup(x => x.GetContactById(id));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.UpdateContact(id, new ContactModel()));
        }

        [TestCaseSource(typeof(AddContactTestCaseSource))]
        public void AddContactTest(ContactModel contact)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.AddContact(It.IsAny<Contact>())).Verifiable();
            //when
            //then
            Assert.DoesNotThrow(() => _service.AddContact(contact));
            Assert.Pass();
            _ContactRepositoryMock.Verify();
        }

        [Test]
        public void AddContactTest_WhenNotEnoughDataAboutContact_ShouldServiceNotFoundExeption()
        {
            //given
            _ContactRepositoryMock.Setup(x => x.AddContact(It.IsAny<Contact>()));
            var contact = new ContactModel() { Value = "" };
            //when
            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.AddContact(contact));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(138)]
        public void DeleteOrRestoreContactTest(int id)
        {
            //given
            Contact contact = new Contact() {Id = id, Value = "123456", ContactType = ContactType.phone, IsDeleted = false };
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, true)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, false)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.GetContactById(contact.Id)).Returns(contact);
            //when                     
            //then
            Assert.DoesNotThrow(() => _service.DeleteContact(id));
            Assert.DoesNotThrow(() => _service.RestoreContact(id));
            Assert.Pass();
            _ContactRepositoryMock.VerifyAll();
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(11)]
        public void DeleteOrRestoreContactTest_WhenContactNotFound_ShouldServiceNotFoundExeption(int id)
        {
            //given
            Contact contact = new Contact() { Id = id, Value = "123456", ContactType = ContactType.phone, IsDeleted = false };
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, true)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, false)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.GetContactById(contact.Id));
            //when

            //then

            Assert.Throws<ServiceNotFoundExeption>(() => _service.DeleteContact(id));
            Assert.Throws<ServiceNotFoundExeption>(() => _service.RestoreContact(id));
        }

        [TestCaseSource(typeof(GetContactByIdTestCaseSource))]
        public void GetContactByIdTest(int id, Contact contact)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.GetContactById(id)).Returns(contact).Verifiable();
            //when

            //then
            Assert.DoesNotThrow(() => _service.GetContactById(id));
            Assert.Pass();
            _ContactRepositoryMock.Verify();
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(11)]
        public void GetContactByIdTest_WhenContactNotFound_ShouldServiceNotFoundExeption(int id)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.GetContactById(id));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.GetContactById(id));
        }

        [TestCaseSource(typeof(GetAllContactTestCaseSource))]
        public void GetAllContactsTest(List<Contact> contacts)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.GetAllContacts()).Returns(contacts).Verifiable();
            //when

            //then
            Assert.DoesNotThrow(() => _service.GetAllContacts());
            Assert.Pass();
            _ContactRepositoryMock.Verify();
        }
    }
}
