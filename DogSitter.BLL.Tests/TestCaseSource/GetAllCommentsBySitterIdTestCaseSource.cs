using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllComentsBySitterIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Sitter sitter = new Sitter()
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                IsDeleted = false,
            };

            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = 1,
                    Text = "Privet1",
                    Date = new DateTime(1999, 11, 11),
                    IsDeleted = false,
                },
                new Comment()
                {
                    Id = 2,
                    Text = "Privet2",
                    Date = new DateTime(1999, 1, 1),
                    IsDeleted = false,
                }
            };

            yield return new Object[] { id, sitter, comments };
        }
    }
}
