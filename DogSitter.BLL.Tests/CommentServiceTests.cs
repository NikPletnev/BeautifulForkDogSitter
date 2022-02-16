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
        private CommentService _comment;
        private CommentTestCaseSourse _commentMocks;

        public CommentServiceTests()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
        }

        [SetUp]
        public void SetUp()
        {
            _comment = new CommentService(_commentRepositoryMock.Object, _mapper);
            _commentMocks = new CommentTestCaseSourse();
        }

        [Test]
        public void GetGetAllComments_ShouldReturnComments()
        {
            //given
            var expected = _commentMocks.GetMockComments();
            _commentRepositoryMock.Setup(x => x.GetAll()).Returns(expected);

            //when
            var actual = _comment.GetAll();

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            _commentRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void GetCommentByIdTest()
        {
            //given 
            var expected = _commentMocks.GetMockComment();
            _commentRepositoryMock.Setup(m => m.GetById(expected.Id)).Returns(expected);

            //when 
            var actual = _comment.GetById(3);

            //then
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.Text, expected.Text);
            Assert.AreEqual(actual.Date, expected.Date);
            _commentRepositoryMock.Verify(m => m.GetById(expected.Id));
        }
        [Test]
        public void GetCommentByIdNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.GetById(0));
        }

        [Test]
        public void AddCommentTest()
        {
            //given
            _commentRepositoryMock.Setup(m => m.Add(It.IsAny<Comment>()));
            var commentModel = _commentMocks.GetMockCommentModel();
            //when 
            _comment.Add(commentModel);

            //then
            _commentRepositoryMock.Verify(m => m.Add(It.IsAny<Comment>()), Times.Once);
        }

        [Test]
        public void UpdateCommentTest()
        {
            //given
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Comment());

            //when
            _comment.Update(new CommentModel());

            //then
            _commentRepositoryMock.Verify(m => m.Update(It.IsAny<Comment>()), Times.Once());
            _commentRepositoryMock.Verify(m => m.Update(
                new Comment(), true), Times.Never());
        }

        [Test]
        public void UpdateCommentNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.Update(new CommentModel()));
        }

        [Test]
        public void DeleteCommentTest()
        {
            //given
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), true));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Comment());

            //when
            _comment.DeleteById(new CommentModel());

            //then
            _commentRepositoryMock.Verify(m => m.Update(It.IsAny<Comment>()), Times.Never());
            _commentRepositoryMock.Verify(m => m.Update(
                It.IsAny<Comment>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void DeleteCommentNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), It.IsAny<bool>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.DeleteById(new CommentModel()));
        }
        [Test]
        public void RestoreCommentTest()
        {
            //given
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), true));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Comment());

            //when
            _comment.Restore(10);

            //then
            _commentRepositoryMock.Verify(m => m.Update(It.IsAny<Comment>(), false), Times.Once());

        }

        [Test]
        public void RestoreOrderNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), It.IsAny<bool>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.DeleteById(new CommentModel()));
        }
    }
}
