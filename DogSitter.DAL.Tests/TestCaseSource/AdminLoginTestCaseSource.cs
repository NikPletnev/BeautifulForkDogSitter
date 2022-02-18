using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class AdminLoginTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  Contacts = new List<Contact>() { new Contact { Value = "12345678", ContactType = ContactType.phone} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  Contacts = new List<Contact> { new Contact { Value = "qwertyu@icloud.com", ContactType = ContactType.mail} },
                  IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true }
            };

            Contact contact = new Contact() {Id = 1, Value = "12345678", ContactType = ContactType.phone };

            string pass = "VANYA1234";

            Admin expected = new Admin()
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                Contacts = new List<Contact>() { new Contact { Id = 1, Value = "12345678", ContactType = ContactType.phone } },
                IsDeleted = false
            };

            yield return new object[] { admins, contact, pass, expected };
        }
    }
}