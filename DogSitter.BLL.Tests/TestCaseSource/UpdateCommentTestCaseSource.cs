using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    internal class UpdateCommentTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;
            Comment comment = new Comment()
            {
                Text = "Test 1",
                IsDeleted = false
            };

            CommentModel model = new CommentModel()
            {
                Text = "Test 1",
                IsDeleted = false
            };

            yield return new object[] { id, comment, model };

            int id2 = 100;
            Comment comment2 = new Comment()
            {
                Text = "Test 2",
                IsDeleted = false
            };

            CommentModel model2 = new CommentModel()
            {
                Text = "Test 2",
                IsDeleted = false
            };

            yield return new object[] { id2, comment2, model2 };

        }
    }
}
