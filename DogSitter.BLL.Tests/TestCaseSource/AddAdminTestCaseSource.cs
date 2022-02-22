using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddAdminTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            AdminModel model = new AdminModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } }
            };

            yield return new object[] { model };

            AdminModel model2 = new AdminModel()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<ContactModel> { new ContactModel { Value = "qwertyu@icloud.com", ContactType = ContactType.Mail } },
            };

            yield return new object[] { model2 };

        }
    }
}
