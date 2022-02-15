using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class CommentTestCaseSource 
    {
        public static List<Comment> GetComments() =>
            new List<Comment>()
            {
                new Comment()
                {
                    Id = 1,
                    Text = "Test1",
                    Date = DateTime.Now,
                    IsDeleted = false
                },
                 new Comment()
                {
                    Id = 2,
                    Text = "Test2",
                    Date = DateTime.Now,
                    IsDeleted = true
                },
            };
        public static Comment GetComment() =>
                new Comment()
                {
                    Id = 3,
                    Text = "Test3",
                    Date = DateTime.Now,
                    IsDeleted = false,
                    Order = new Order()
                };
    }
}
