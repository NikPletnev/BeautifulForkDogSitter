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
    public class GetAllContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Contact> contacts = new List<Contact>() {
              new Contact() { Value = "89871234567", ContactType = ContactType.phone, IsDeleted = false },
              new Contact() { Value = "@qwerty", ContactType = ContactType.mail, IsDeleted = false },
              new Contact() { Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = true }
            };

            yield return new object[] { contacts };
        }
    }
}