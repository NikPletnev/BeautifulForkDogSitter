using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
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
    public class CommentServiceTests
    {
        private readonly Mock<ICommentRepository> _commentRepositoryMock;
        private readonly IMapper _mapper;
        private readonly CommentService _service;

        public CommentServiceTests()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new CommentService(_commentRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(nameof(UpdateCommentTestCaseSource))]
        public void UpdateCommentTest(int id, Comment entity, CommentModel model)
        {
            //given
            _commentRepositoryMock.Setup(x => x.Update(entity)).Verifiable();
            _commentRepositoryMock.Setup(x => x.GetById(id)).Returns(entity).Verifiable();
            //when
            _service.Update(id, model);
            //then
            _commentRepositoryMock.Verify(x => x.GetById(id));
            _commentRepositoryMock.Verify(x => x.Update(entity), Times.Once());
        }
    }
}
