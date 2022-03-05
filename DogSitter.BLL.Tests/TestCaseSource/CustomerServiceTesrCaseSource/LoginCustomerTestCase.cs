using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class LoginCustomerTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var customer = new Customer()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            var expected = new CustomerModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            Contact contact = new Contact() { Id = 1, Value = "12345678", ContactType = ContactType.Phone };

            string password = "123456";

            yield return new object[] { customer, expected, contact, password };
        }
    }
}
