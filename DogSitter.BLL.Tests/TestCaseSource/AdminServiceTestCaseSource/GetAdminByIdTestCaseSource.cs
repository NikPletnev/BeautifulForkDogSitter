using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAdminByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;
            Admin admin = new Admin()
            {
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "VANYA1234",
                Contacts = new List<Contact>() { },
                IsDeleted = false
            };

            yield return new object[] { id, admin };

            int id2 = 99;

            Admin admin2 = new Admin()
            {
                FirstName = "Иван2",
                LastName = "Иванов2",
                Password = "2VANYA1234",
                Contacts = new List<Contact> { },
                IsDeleted = false
            };

            yield return new object[] { id2, admin2 };

        }
    }
}