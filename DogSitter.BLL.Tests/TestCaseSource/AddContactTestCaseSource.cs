using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            ContactModel contact = new ContactModel() { Value = "89871234567", ContactType = ContactType.Phone, IsDeleted = false };

            yield return new object[] { contact };

            ContactModel contact2 = new ContactModel() { Value = "@qwerty", ContactType = ContactType.Mail, IsDeleted = false };

            yield return new object[] { contact2 };

            ContactModel contact3 = new ContactModel() { Value = "qwerty123@icloud.com", ContactType = ContactType.Mail, IsDeleted = true };

            yield return new object[] { contact3 };
        }
    }
}