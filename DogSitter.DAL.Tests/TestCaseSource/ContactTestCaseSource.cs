using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class ContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Contact> contacts = new List<Contact>() {
              new Contact() { Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false },
              new Contact() { Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false },
              new Contact() { Value = "qwerty123@icloud.com", ContactType = ContactType.Mail, IsDeleted = true }
            };

            yield return new object[] { contacts };
        }
    }
}
