using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class CommentRepositoryTests
    {
        private DogSitterContext _context;
        private CommentRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase(databaseName: "CommentTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new CommentRepository(_context);

            var comments = CommentTestCaseSource.GetComments();
            _context.Comments.AddRange(comments);

            _context.SaveChanges();
        }

        [Test]
        public void GetAllCommentTest()
        {
            //given           
            var expected = _context.Comments.Where(e => !e.IsDeleted);

            //when
            var actual = _repository.GetAll();

            //then
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Where(e => e.IsDeleted), actual.Where(a => a.IsDeleted));

        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetCommentByIdTest(int id)
        {
            //given
            var expected = _context.Comments.Find(id);

            //when
            var actual = _repository.GetById(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddCommentTest()
        {
            //given
            var expected = CommentTestCaseSource.GetComment();

            //when
            _repository.Add(expected);

            var actual = _context.Comments.FirstOrDefault(x => x.Id == expected.Id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void UpdateCommentTest()
        {
            //given
            var comment = CommentTestCaseSource.GetComment();
            _context.Comments.Add(comment);
            _context.SaveChanges();

            var expected = new Comment()
            {
                Id = comment.Id,
                Text = "ChangeqqqText",
                Date = DateTime.Now,
                IsDeleted = comment.IsDeleted,
            };

            //when
            _repository.Update(comment, expected);
            var actual = _context.Comments.First(x => x.Id == comment.Id);

            //then
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [Test]
        public void UpdateIsDeleteCommentTest()
        {
            //given
            var comment = CommentTestCaseSource.GetComment();

            //when
            _repository.Update(comment, true);

            //then
            Assert.AreEqual(comment.IsDeleted, true);
        }

        [Test]
        public void RestoreCommentTest()
        {
            //given
            var comment = CommentTestCaseSource.GetComment();

            //when
            _repository.Update(comment, false);

            //then
            Assert.AreEqual(comment.IsDeleted, false);
        }

        [TestCaseSource(typeof(GetAllComentsBySitterIdTestCaseSource))]
        public void GetAllComentsBySitterIdTest(List<Order> orders, int id, List<Comment> expected)
        {
            //given
            _context.Orders.AddRange(orders);
            _context.SaveChanges();
            //when
            var actual = _repository.GetAllComentsBySitterId(id);
            //then
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
