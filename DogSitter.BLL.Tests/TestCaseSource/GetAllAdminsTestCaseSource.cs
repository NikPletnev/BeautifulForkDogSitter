using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllAdminsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234",
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.phone} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.mail} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true }
            };

            yield return new object[] { admins };
        }
    }
}