using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class AdminTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234",
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = Enums.ContactType.Phone} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = Enums.ContactType.Mail} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true }
            };

            yield return new object[] { admins };
        }
    }
}
