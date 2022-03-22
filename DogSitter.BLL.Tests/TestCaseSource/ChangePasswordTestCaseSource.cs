using DogSitter.BLL.Helpers;
using DogSitter.DAL.Entity;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class ChangePasswordTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            User user = new User()
            {
                Id = 1,
                Password = "12345",
                FirstName = "FirstName1",
                LastName = "LastName1",
                IsDeleted = false
            };

            var password = PasswordHash.HashPassword("111111");

            int id = 1;

            yield return new object[] { user, password, id };

        }
    }
}
