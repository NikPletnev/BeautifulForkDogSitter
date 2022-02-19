using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class CommentTestCaseSourse
    {
        public List<Comment> GetMockComments() =>
            new List<Comment>()
            {
                new Comment()
                {
                    Id = 1,
                    Text ="Test1",
                    Date = DateTime.Now,
                    IsDeleted = false
                },
                 new Comment()
                {
                    Id = 2,
                    Text ="Test2",
                    Date = DateTime.Now,
                    IsDeleted = true
                },
            };
        public Comment GetMockComment() =>
            new Comment()
            {
                Id = 3,
                Text = "Test3",
                Date = DateTime.Now,
                IsDeleted = false
            };
        public CommentModel GetMockCommentModel() =>
            new CommentModel()
            {
                Id = 3,
                Text = "Test4",
                Date = DateTime.Now
            };
    }
}
