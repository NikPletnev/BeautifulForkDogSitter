using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllAdminsWithContactsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.phone} }},
              new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.mail} }}
            };

            List<AdminModel> adminsModel = new List<AdminModel>() {
              new AdminModel() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.phone} },
                  },
              new AdminModel() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = ContactType.mail} },
                  }
            };

            yield return new object[] { admins, adminsModel };
        }
    }
}
