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
    public class GetTokenTestCaseSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            var admin = new AdminModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            var customer = new CustomerModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            var sitter = new SitterModel()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "123456",
                Contacts = new List<ContactModel>() { new ContactModel { Value = "12345678", ContactType = ContactType.Phone } },
                IsDeleted = false
            };

            
            yield return new object[] { admin };
            yield return new object[] { customer };
            yield return new object[] { sitter };

        }
    }
}
