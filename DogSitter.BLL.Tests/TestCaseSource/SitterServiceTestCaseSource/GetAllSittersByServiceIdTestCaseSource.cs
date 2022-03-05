using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllSittersByServiceIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Serviсe service =
              new Serviсe()
              {
                  Id = 1,
                  Name = "Name1",
                  Description = "Description1",
                  Price = 1000m,
                  DurationHours = 1.0,
                  Sitter = new Sitter()
                  {
                      Id = 1,
                      FirstName = "FirstName1",
                      LastName = "LastName1",
                      Password = "Password1",
                      IsDeleted = false
                  },
                  IsDeleted = false
              };

            List<Sitter> expected = new List<Sitter>()
                  {
                      new Sitter()
                      {
                          Id = 1,
                          FirstName = "Test1",
                          LastName = "Test1",
                          Password = "strong",
                          IsDeleted = false,
                      }
            };

            yield return new object[] { id, service, expected };
        }
    }
}

