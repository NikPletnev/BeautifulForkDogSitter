using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllSittersWithWorkTimeBySubwayStationTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            SubwayStation subwayStation = new SubwayStation()
            {
                Id = 1,
                Name = "Name1",
                Sitters = new List<Sitter>()
                {
                    new Sitter()
                    {
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        Contacts = new List<Contact>(),
                        IsDeleted = false
                    }
                }
            };

            SubwayStationModel subwayStationModel = new SubwayStationModel()
            {
                Id = 1,
                Name = "Name1"
            };

            List<Sitter> sitters = new List<Sitter>()
            {
                new Sitter()
                {
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        Contacts = new List<Contact>(),
                        IsDeleted = false
                },
                 new Sitter()
                {
                        Id = 2,
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        Password = "Password2",
                        Contacts = new List<Contact>(),
                        IsDeleted = true
                }
            };

            yield return new object[] { subwayStation, subwayStationModel, sitters };
        }

    }
}
