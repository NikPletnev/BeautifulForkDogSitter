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
        private readonly Mock<IContactRepository> _contactRepositoryMock;
        private readonly Mock<ICustomerRepository> _customerRepMock;
        private readonly Mock<IAdminRepository> _adminRepMock;
        private readonly Mock<ISitterRepository> _sitterRepMock;
        private readonly IMapper _mapper;
        private readonly ContactService _service;

        public ContactServiceTests()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _adminRepMock = new Mock<IAdminRepository>();
            _sitterRepMock = new Mock<ISitterRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new ContactService(_contactRepositoryMock.Object, _mapper,
            _customerRepMock.Object, _adminRepMock.Object, _sitterRepMock.Object);
        }

        [TestCaseSource(typeof(UpdateContactTestCaseSource))]
        public void UpdateContactTest(int id, Contact entity, ContactModel model)
        {
            //given
            _contactRepositoryMock.Setup(x => x.UpdateContact(It.IsAny<Contact>(), entity)).Verifiable();
            _contactRepositoryMock.Setup(x => x.GetContactById(id)).Returns(entity).Verifiable();
            //when
            _service.UpdateContact(id, model);
            //then
            _contactRepositoryMock.Verify(x => x.UpdateContact(It.IsAny<Contact>(), entity), Times.Once);
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
        }

        [TestCase(100)]
        public void UpdateContactTest_WhenNotEnoughDataAboutContact_ShouldThrowServiceNotEnoughDataExeption(int id)
        {
            //given
            var contactModel = new ContactModel() { Value = "" };

            //when

            //then

            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.UpdateContact(id, contactModel));
            _contactRepositoryMock.Verify(x => x.UpdateContact(It.IsAny<Contact>(), It.IsAny<Contact>()), Times.Never);
            _contactRepositoryMock.Verify(x => x.GetContactById(It.IsAny<int>()), Times.Never);
        }

        [TestCase(100)]
        public void UpdateContactTest_WhenContactNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _contactRepositoryMock.Setup(x => x.UpdateContact(It.IsAny<Contact>(), It.IsAny<Contact>()));
            _contactRepositoryMock.Setup(x => x.GetContactById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.UpdateContact(id, new ContactModel()));
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
            _contactRepositoryMock.Verify(x => x.UpdateContact(It.IsAny<Contact>(), It.IsAny<Contact>()), Times.Never);
        }

        [TestCaseSource(typeof(AddContactTestCaseSource))]
        public void AddContactTest(ContactModel contact)
        {
            //given
            _contactRepositoryMock.Setup(x => x.AddContact(It.IsAny<Contact>()));
            //when
            _service.AddContact(contact);
            //then
            _contactRepositoryMock.Verify(x => x.AddContact(It.IsAny<Contact>())); 
        }

        [Test]
        public void AddContactTest_WhenNotEnoughDataAboutContact_ShouldThrowEntityNotFoundException()
        {
            //given
            _contactRepositoryMock.Setup(x => x.AddContact(It.IsAny<Contact>()));
            var contact = new ContactModel() { Value = "" };
            //when
            //then
            Assert.Throws<ServiceNotEnoughDataExeption>(() => _service.AddContact(contact));
            _contactRepositoryMock.Verify(x => x.AddContact(It.IsAny<Contact>()), Times.Never);
        }

        [TestCase(138)]
        public void DeleteContactTest(int id)
        {
            //given
            Contact contact = new Contact() {Id = id, Value = "123456", ContactType = ContactType.Phone, IsDeleted = false };
            _contactRepositoryMock.Setup(x => x.UpdateContact(contact, true)).Verifiable();
            _contactRepositoryMock.Setup(x => x.GetContactById(contact.Id)).Returns(contact);
            //when
            _service.DeleteContact(id);
            //then
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
            _contactRepositoryMock.Verify(x => x.UpdateContact(contact, true), Times.Once);
        }

        [TestCase(138)]
        public void RestoreContactTest(int id)
        {
            //given
            Contact contact = new Contact() { Id = id, Value = "123456", ContactType = ContactType.Phone, IsDeleted = true };
            _contactRepositoryMock.Setup(x => x.UpdateContact(contact, false)).Verifiable();
            _contactRepositoryMock.Setup(x => x.GetContactById(contact.Id)).Returns(contact);
            //when
            _service.RestoreContact(id);
            //then
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
            _contactRepositoryMock.Verify(x => x.UpdateContact(contact, false), Times.Once);
        }

        [TestCase(11)]
        public void DeleteOrRestoreContactTest_WhenContactNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            Contact contact = new Contact() { Id = id, Value = "123456", ContactType = ContactType.Phone, IsDeleted = false };
            _contactRepositoryMock.Setup(x => x.UpdateContact(contact, true)).Verifiable();
            _contactRepositoryMock.Setup(x => x.UpdateContact(contact, false)).Verifiable();
            _contactRepositoryMock.Setup(x => x.GetContactById(contact.Id));
            //when

            //then

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteContact(id));
            Assert.Throws<EntityNotFoundException>(() => _service.RestoreContact(id));
            _contactRepositoryMock.Verify(x => x.UpdateContact(contact, It.IsAny<bool>()), Times.Never);
            _contactRepositoryMock.Verify(x => x.GetContactById(contact.Id));
        }

        [TestCaseSource(typeof(GetContactByIdTestCaseSource))]
        public void GetContactByIdTest(int id, Contact contact)
        {
            //given
            _contactRepositoryMock.Setup(x => x.GetContactById(id)).Returns(contact).Verifiable();
            //when
            var actual = _service.GetContactById(id);
            //then
            Assert.AreEqual(actual, new ContactModel() { Value = contact.Value, ContactType = contact.ContactType, Id = contact.Id, IsDeleted = contact.IsDeleted});
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
        }

        [TestCase(11)]
        public void GetContactByIdTest_WhenContactNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _contactRepositoryMock.Setup(x => x.GetContactById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetContactById(id));
            _contactRepositoryMock.Verify(x => x.GetContactById(id), Times.Once);
        }

        [TestCaseSource(typeof(GetAllContactTestCaseSource))]
        public void GetAllContactsTest(List<Contact> contacts, List<ContactModel> expected)
        {
            //given
            _contactRepositoryMock.Setup(x => x.GetAllContacts()).Returns(contacts).Verifiable();
            //when
            List<ContactModel> actual = _service.GetAllContacts();
            //then
            Assert.AreEqual(actual.Count, contacts.Count);
            CollectionAssert.AreEqual(actual, expected);
            _contactRepositoryMock.Verify(x => x.GetAllContacts(), Times.Once);
        }
    }
}
