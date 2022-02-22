using DogSitter.DAL.Entity;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class SubwayStationTestCaseSourse
    {
        public static List<SubwayStation> GetSubwayStations() =>
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
                            FirstName = "FirstName4",
                            LastName = "LastName4",
                            Password = "Password4",
                            PassportId = 1,
                            IsDeleted = false
                        },
                        new Sitter()
                        {
                            Id = 2,
                            FirstName = "FirstName5",
                            LastName = "LastName5",
                            Password = "Password5",
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
                            FirstName = "FirstName2",
                            LastName = "LastName2",
                            Password = "Passwor2",
                            PassportId = 3,
                            IsDeleted = true
                        },
                        new Sitter()
                        {
                            Id = 4,
                            FirstName = "FirstName3",
                            LastName = "LastName3",
                            Password = "Password3",
                            PassportId = 4,
                            IsDeleted = false
                        },
                    }
                },

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
                            FirstName = "FirstName6",
                            LastName = "LastName6",
                            Password = "Password7",
                            PassportId = 5,
                            IsDeleted = false
                        },
                        new Sitter()
                        {
                            Id = 6,
                            FirstName = "FirstName1",
                            LastName = "LastName2",
                            Password = "Password5",
                            PassportId = 6,
                            IsDeleted = false
                        },
                    }
                }
            };
        public static SubwayStation GetSubwayStation() =>
        new SubwayStation()
        {
            Id = 4,
            Name = "Name3",
            IsDeleted = false,
            Sitters = new List<Sitter>()
            {
                         new Sitter()
                         {
                             Id = 7,
                             FirstName = "FirstName5",
                             LastName = "LastName5",
                             Password = "Password5",
                             PassportId = 7,
                             IsDeleted = false
                         },
                         new Sitter()
                         {
                             Id = 8,
                             FirstName = "FirstName6",
                             LastName = "LastName6",
                             Password = "Password6",
                             PassportId = 8,
                             IsDeleted = true
                         },
            }
        };

    };



}
