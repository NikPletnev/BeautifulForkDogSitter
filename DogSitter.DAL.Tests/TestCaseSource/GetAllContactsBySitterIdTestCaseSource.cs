using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllContactsBySitterIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            List<Sitter> sitters = new List<Sitter>() {
              new Sitter() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone},
                      new Contact { Value = "123456555578", ContactType = ContactType.Phone} },
                  IsDeleted = false, AddressId = 1, PassportId = 2 },
              new Sitter() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail} },
                  IsDeleted = false, AddressId = 3, PassportId = 4  },
              new Sitter() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true, AddressId = 5, PassportId = 6  }
            };

            List<Contact> expected = new List<Contact>() { new Contact {Id = 1, Value = "12345678", ContactType = ContactType.Phone},
                      new Contact { Id = 2, Value = "123456555578", ContactType = ContactType.Phone} };

            yield return new object[] { id, sitters, expected };
        }
    }
}