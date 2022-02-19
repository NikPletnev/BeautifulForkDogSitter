using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllAdminsTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Admin> admins = new List<Admin>() {
              new Admin() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" , IsDeleted = false },
              new Admin() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234", IsDeleted = false }
            };

            List<AdminModel> adminsModel = new List<AdminModel>() {
              new AdminModel() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" },
              new AdminModel() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234" } };

            yield return new object[] { admins, adminsModel };
        }
    }
}