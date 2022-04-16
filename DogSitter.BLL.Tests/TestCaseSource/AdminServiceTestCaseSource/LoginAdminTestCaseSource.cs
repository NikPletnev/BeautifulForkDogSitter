using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class LoginAdminTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var admin = new Admin()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = PasswordHash.HashPassword("123456"),
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };
            var expected = new UserModel()
            {

                FirstName = "Иван",
                LastName = "Иванов",
                Password = PasswordHash.HashPassword("123456"),
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            Contact contact = new Contact() { Id = 1, Value = "12345678", ContactType = ContactType.Phone, User = admin };

            string password = "123456";

            yield return new object[] { expected, contact, password };
        }
    }
}
