using AutoMapper;
using DogSitter.BLL.Configs;
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
    public class ContactServiceTests
    {
        private Mock<IContactRepository> _contactRepositoryMock;
        private Mock<ICustomerRepository> _customerRepMock;
        private Mock<IAdminRepository> _adminRepMock;
        private Mock<ISitterRepository> _sitterRepMock;
        private IMapper _mapper;
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _adminRepMock = new Mock<IAdminRepository>();
            _sitterRepMock = new Mock<ISitterRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new ContactService(_contactRepositoryMock.Object, _mapper,
            _customerRepMock.Object, _adminRepMock.Object, _sitterRepMock.Object);
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
