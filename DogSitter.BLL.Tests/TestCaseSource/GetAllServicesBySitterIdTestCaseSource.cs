using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllServicesBySitterIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Sitter sitter =
              new Sitter()
              {
                  Id = 1,
                  FirstName = "FirstName1",
                  LastName = "LastName1",
                  Password = "Password1",
                  Services = new List<Serviсe>()
                  {
                      new Serviсe()
                      {
                           Name = "Name1",
                           Description = "Description1",
                           Price = 1000m,
                           DurationHours = 1.0,
                           IsDeleted = false
                      },
                      new Serviсe()
                      {
                          Name = "Name2",
                          Description = "Description2",
                          Price = 2000m,
                          DurationHours = 2.0,
                          IsDeleted = true
                      }
                  },
                  IsDeleted = false
              };

            List<Serviсe> expected = new List<Serviсe>()
                  {
                      new Serviсe()
                      {
                           Name = "Name1",
                           Description = "Description1",
                           Price = 1000m,
                           DurationHours = 1.0,
                           IsDeleted = false
                      },
                      new Serviсe()
                      {
                          Name = "Name2",
                          Description = "Description2",
                          Price = 2000m,
                          DurationHours = 2.0,
                          IsDeleted = true
                      }
            };

            yield return new object[] { id, sitter, expected };
        }
    }
}
