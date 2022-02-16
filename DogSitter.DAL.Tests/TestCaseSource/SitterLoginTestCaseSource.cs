using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class SitterLoginTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Sitter> sitters = new List<Sitter>() {
              new Sitter() { FirstName = "Test1", LastName = "Test1", Password = "strong" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.phone} },
                  IsDeleted = false },
              new Sitter() { FirstName = "Test2", LastName = "Иванов2", Password = "2strong",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.mail} },
                  IsDeleted = false },
              new Sitter() { FirstName = "Test3", LastName = "Иванов2", Password = "veryStrong", IsDeleted = true }
            };

            Contact contact = new Contact() { Id = 1, Value = "12345678", ContactType = ContactType.phone };

            string pass = "strong";

            Sitter expected = new Sitter()
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "Test1",
                Password = "strong",
                Contacts = new List<Contact>() { new Contact { Id = 1, Value = "12345678", ContactType = ContactType.phone } },
                IsDeleted = false
            };

            yield return new object[] { sitters, contact, pass, expected };
        }
    }
}
