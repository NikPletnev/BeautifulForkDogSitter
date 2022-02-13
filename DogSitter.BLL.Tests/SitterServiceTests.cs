using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests
{
    public class SitterServiceTests
    {
        private readonly Mock<ISitterRepository> _sitterRepositoryMock;
        private readonly IMapper _mapper;
        private readonly SitterService _service;

        public SitterServiceTests()
        {
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new SitterService(_sitterRepositoryMock.Object, _mapper);
        }

        [TestCase(1)]
        public void ConfirmProfileSitterByIdTest(int id)
        {
            //given
            Sitter sitter = new Sitter()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                IsDeleted = false,
                AddressId = 1,
                PassportId = 2,
                Verified = false
            };
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Returns(sitter).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditStateProfileSitterById(id, true)).Verifiable();

            //when
            _service.ConfirmProfileSitterById(id);

            //then
            _sitterRepositoryMock.Verify(x => x.EditStateProfileSitterById(id, true), Times.Once);
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(1)]
        public void ConfirmOrBlockProfileSitterByIdTest_WhenSitterNotFound_ShouldThrowServoceNotFoundExeption(int id)
        {
            //given           
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditStateProfileSitterById(id, It.IsAny<bool>())).Verifiable();

            //when

            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.ConfirmProfileSitterById(id));
            Assert.Throws<ServiceNotFoundExeption>(() => _service.BlockProfileSitterById(id));
            _sitterRepositoryMock.Verify(x => x.EditStateProfileSitterById(id, It.IsAny<bool>()), Times.Never);
        }

        [TestCase(2)]
        public void BlockProfileSitterByIdTest(int id)
        {
            //given
            Sitter sitter = new Sitter()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                IsDeleted = false,
                AddressId = 1,
                PassportId = 2,
                Verified = true
            };
            _sitterRepositoryMock.Setup(s => s.GetById(id)).Returns(sitter).Verifiable();
            _sitterRepositoryMock.Setup(x => x.EditStateProfileSitterById(id, false)).Verifiable();

            //when
            _service.BlockProfileSitterById(id);

            //then
            _sitterRepositoryMock.Verify(x => x.EditStateProfileSitterById(id, false), Times.Once);
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once);
        }
    }
}
