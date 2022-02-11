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
            _ContactRepositoryMock.Setup(x => x.GetContactById(id)).Returns(entity).Verifiable();
            //when

            //then
            Assert.DoesNotThrow(() => _service.UpdateContact(id, model));
            Assert.Pass();
            _ContactRepositoryMock.Verify(x => x.UpdateContact(entity), Times.Once);
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
            _service.AddContact(contact);
            //then
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
        public void DeleteContactTest(int id)
        {
            //given
            Contact contact = new Contact() {Id = id, Value = "123456", ContactType = ContactType.phone, IsDeleted = false };
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, true)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.GetContactById(contact.Id)).Returns(contact);
            //when
            _service.DeleteContact(id);
            //then
            _ContactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
            _ContactRepositoryMock.Verify(x => x.UpdateContact(id, true), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(138)]
        public void RestoreContactTest(int id)
        {
            //given
            Contact contact = new Contact() { Id = id, Value = "123456", ContactType = ContactType.phone, IsDeleted = true };
            _ContactRepositoryMock.Setup(x => x.UpdateContact(contact.Id, false)).Verifiable();
            _ContactRepositoryMock.Setup(x => x.GetContactById(contact.Id)).Returns(contact);
            //when
            _service.RestoreContact(id);
            //then
            _ContactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
            _ContactRepositoryMock.Verify(x => x.UpdateContact(id, false), Times.Once);
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
            var actual = _service.GetContactById(id);
            Assert.AreEqual(actual, new ContactModel() { Value = contact.Value, ContactType = contact.ContactType, Id = contact.Id, IsDeleted = contact.IsDeleted});
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
        public void GetAllContactsTest(List<Contact> contacts, List<ContactModel> expected)
        {
            //given
            _ContactRepositoryMock.Setup(x => x.GetAllContacts()).Returns(contacts).Verifiable();
            //when

            //then
            List<ContactModel> actual = _service.GetAllContacts();
            Assert.AreEqual(actual.Count, contacts.Count);
            CollectionAssert.AreEqual(actual, expected);
            _ContactRepositoryMock.Verify();
        }
    }
}
