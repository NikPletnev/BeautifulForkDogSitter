using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Contact> contacts = new List<Contact>() {
              new Contact() { Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false },
              new Contact() { Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false },
              new Contact() { Value = "qwerty123@icloud.com", ContactType = ContactType.Mail, IsDeleted = true }
            };

            List<ContactModel> models = new List<ContactModel>(){
              new ContactModel() { Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false },
              new ContactModel() { Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false },
              new ContactModel() { Value = "qwerty123@icloud.com", ContactType = ContactType.Mail, IsDeleted = true }
            };

            yield return new object[] { contacts, models };
        }
    }
}