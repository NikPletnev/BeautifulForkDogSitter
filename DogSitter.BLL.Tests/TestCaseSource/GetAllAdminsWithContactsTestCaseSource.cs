using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllAdminsWithContactsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone} }},
              new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail} }}
            };

            List<AdminModel> adminsModel = new List<AdminModel>() {
              new AdminModel() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone} },
                  },
              new AdminModel() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail} },
                  }
            };

            yield return new object[] { admins, adminsModel };
        }
    }
}
