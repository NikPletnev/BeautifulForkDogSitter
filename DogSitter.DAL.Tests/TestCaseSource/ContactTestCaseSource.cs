using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class ContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Contact> contacts = new List<Contact>() {
              new Contact() { Value = "89871234567", IsDeleted = false },
              new Contact() { Value = "@qwerty", IsDeleted = false },
              new Contact() { Value = "qwerty123@icloud.com", IsDeleted = true }
            };

            yield return new object[] { contacts };

        }
    }
}
