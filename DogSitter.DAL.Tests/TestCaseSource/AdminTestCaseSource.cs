using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class AdminTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234", IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = true }
            };

            var expected = new List<Admin>() {
              new Admin() { Id = 1, FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" },
              new Admin() { Id = 2, FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234"}
            };
        }
    }
}
