using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllContactsByAdminIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone},
                      new Contact { Value = "123456555578", ContactType = ContactType.Phone} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true }
            };

            List<Contact> expected = new List<Contact>() { new Contact {Id = 1, Value = "12345678", ContactType = ContactType.Phone},
                      new Contact { Id = 2, Value = "123456555578", ContactType = ContactType.Phone} };

            yield return new object[] { id, admins, expected };
        }
    }
}
