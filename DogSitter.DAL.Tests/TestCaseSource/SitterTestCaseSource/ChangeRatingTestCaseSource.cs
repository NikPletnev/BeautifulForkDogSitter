using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class ChangeRatingTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Sitter sitterDb = new Sitter()
            {
                Id = 10,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                Contacts = new List<Contact>() { new Contact { Id = 1, Value = "12345678", ContactType = ContactType.Phone } },
                Rating = 0,
                IsDeleted = false
            };

            Sitter sitter = new Sitter()
            {
                Id = 10,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                Contacts = new List<Contact>() { new Contact { Id = 1, Value = "12345678", ContactType = ContactType.Phone } },
                Rating = 10,
                IsDeleted = false
            };

            yield return new object[] { sitterDb, sitter };
        }
    }
}
