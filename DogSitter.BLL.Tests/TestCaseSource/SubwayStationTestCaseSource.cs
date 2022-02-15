using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class SubwayStationTestCaseSource
    {
        public List<SubwayStation> GetSubwayStations() =>
             new List<SubwayStation>()
             {
                new SubwayStation()
                {
                    Id = 1,
                    Name = "Name1",
                    IsDeleted = false,
                    Sitters = new List<Sitter>()
                    {
                         new Sitter()
                         {
                             Id = 1,
                             FirstName = "FirstName1",
                             LastName = "LastName1",
                             Password = "Password1",
                             PassportId = 1,
                             IsDeleted = false
                         },
                         new Sitter()
                         {
                             Id = 2,
                             FirstName = "FirstName2",
                             LastName = "LastName2",
                             Password = "Password2",
                             PassportId = 2,
                             IsDeleted = true
                         },
                    }
                },

                new SubwayStation()
                {
                    Id = 2,
                    Name = "Name2",
                    IsDeleted = true,
                    Sitters = new List<Sitter>()
                    {
                         new Sitter()
                         {
                             Id = 3,
                             FirstName = "FirstName3",
                             LastName = "LastName3",
                             Password = "Password3",
                             PassportId = 3,
                             IsDeleted = false
                         },
                         new Sitter()
                         {
                             Id = 4,
                             FirstName = "FirstName4",
                             LastName = "LastName4",
                             Password = "Password4",
                             PassportId = 4,
                             IsDeleted = true
                         },
                    }
                }
             };

        public SubwayStation GetSubwayStation() =>
                new SubwayStation()
                {
                    Id = 3,
                    Name = "Name3",
                    IsDeleted = false,
                    Sitters = new List<Sitter>()
                    {
                         new Sitter()
                         {
                             Id = 5,
                             FirstName = "FirstName5",
                             LastName = "LastName5",
                             Password = "Password5",
                             PassportId = 5,
                             IsDeleted = false
                         },
                         new Sitter()
                         {
                             Id = 6,
                             FirstName = "FirstName6",
                             LastName = "LastName6",
                             Password = "Password6",
                             PassportId = 6,
                             IsDeleted = true
                         },
                    }
                };

        public SubwayStationModel GetSubwayStationModel() =>
        new SubwayStationModel()
        {
            Id = 3,
            Name = "Name3",
            Sitters = new List<SitterModel>()
            {
                new SitterModel()
                {
                    Id = 5,
                    FirstName = "FirstName5",
                    LastName = "LastName5",
                    Password = "Password5",
                    IsDeleted = false
                },
                new SitterModel()
                {
                     Id = 6,
                     FirstName = "FirstName6",
                     LastName = "LastName6",
                     Password = "Password6",
                     IsDeleted = true
                },
             }
        };
    }
}
