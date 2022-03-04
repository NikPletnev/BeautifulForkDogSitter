using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class UpdateAdminTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;
            Admin admin = new Admin()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            AdminModel model = new AdminModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } }
            };

            yield return new object[] { id, admin, model };

            int id2 = 99;

            Admin admin2 = new Admin()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail } },
                IsDeleted = false
            };

            AdminModel model2 = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail } },
            };

            yield return new object[] { id2, admin2, model2 };

        }
    }
}
