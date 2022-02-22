using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests
{
    public class CommentServiceTests
    {
        private Mock<ICommentRepository> _commentRepositoryMock;
        private Mock<ISitterRepository> _sitterRepositoryMock;
        private IMapper _mapper;
        private CommentService _comment;
        private CommentTestCaseSourse _commentMocks;

        [SetUp]
        public void Setup()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _sitterRepositoryMock = new Mock<ISitterRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _comment = new CommentService(_commentRepositoryMock.Object, _mapper, _sitterRepositoryMock.Object);
            _commentMocks = new CommentTestCaseSourse();
        }

        [Test]
        public void GetAllComments_ShouldReturnComments()
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
        public void DeleteCommentTest()
        {
            //given
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), true));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Comment());

            //when
            _comment.DeleteById(1);

            //then
            _commentRepositoryMock.Verify(m => m.Update(It.IsAny<Comment>(), It.IsAny<Comment>()), Times.Never());
            _commentRepositoryMock.Verify(m => m.Update(
                It.IsAny<Comment>(), It.IsAny<bool>()), Times.Once());
        }

        [Test]
        public void DeleteCommentNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), It.IsAny<bool>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.DeleteById(0));
        }

        [Test]
        public void RestoreOrderNegativeTest()
        {
            _commentRepositoryMock.Setup(m => m.Update(It.IsAny<Comment>(), It.IsAny<bool>()));
            _commentRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Comment)null);

            Assert.Throws<EntityNotFoundException>(() => _comment.DeleteById(0));
        }

        [TestCaseSource(typeof(GetAllComentsBySitterIdTestCaseSource))]
        public void GetAllCommentsBySitterIdTest(int id, Sitter sitter, List<Comment> comments)
        {
            //given
            _sitterRepositoryMock.Setup(x => x.GetById(id)).Returns(sitter);
            _commentRepositoryMock.Setup(x => x.GetAllComentsBySitterId(id)).Returns(comments);

            //when
            var actaul = _comment.GetAllCommentsBySitterId(id);

            //then
            _commentRepositoryMock.Verify(x => x.GetAllComentsBySitterId(id), Times.Once());
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once());
        }

        [TestCaseSource(typeof(GetAllComentsBySitterIdTestCaseSource))]
        public void GetAllCommentsBySitterIdTest_WhenSitterNotFound_ShouldThrowEntityNotFoundException(int id, Sitter sitter, List<Comment> comments)
        {
            //given
            _sitterRepositoryMock.Setup(x => x.GetById(id));
            _commentRepositoryMock.Setup(x => x.GetAllComentsBySitterId(id)).Returns(comments);

            //when

            //then
            Assert.Throws<EntityNotFoundException>(() => _comment.GetAllCommentsBySitterId(id));
            _commentRepositoryMock.Verify(x => x.GetAllComentsBySitterId(id), Times.Never());
            _sitterRepositoryMock.Verify(x => x.GetById(id), Times.Once());
        }
    }
}
