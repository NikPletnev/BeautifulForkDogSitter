using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class CommentTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment(){ Text = "Test text ONE", Date = DateTime.Now, IsDeleted = false},
                new Comment(){ Text = "Test text TWO", Date = DateTime.Now, IsDeleted = true}
            };

            yield return new object[] { comments };

        }
    }
}
