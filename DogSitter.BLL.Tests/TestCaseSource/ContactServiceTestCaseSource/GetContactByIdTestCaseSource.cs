using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetContactByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Contact contact = new Contact() { Id = 1, Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false };

            yield return new object[] { id, contact };

            int id2 = 4;

            Contact contact2 = new Contact() { Id = 4, Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false };

            yield return new object[] { id2, contact2 };

            int id3 = 99;

            Contact contact3 = new Contact() { Id = 99, Value = "qwerty123@icloud.com", ContactType = ContactType.Mail, IsDeleted = true };

            yield return new object[] { id3, contact3 };
        }
    }
}