using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAllSittersWithWorkTimeBySubwayStationTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            SubwayStation subwayStation = new SubwayStation()
            {
                Id = 73,
                Name = "Name1",
                Sitters = new List<Sitter>()
                  {
                    new Sitter()
                    {
                        Id = 11,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        WorkTime = new List<WorkTime>()
                        {
                            new WorkTime()
                            {
                                Id = 11,
                                Start = DateTime.Now,
                                End = DateTime.Now,
                                Weekday = Weekday.Sunday
                            }
                        },
                        SubwayStation = new SubwayStation()
                        {
                            Id = 73,
                            Name = "Name1",
                            IsDeleted = false,
                        }
                    },
                    new Sitter()
                    {
                        Id = 22,
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        Password = "Password2",
                        WorkTime = new List<WorkTime>(),
                        IsDeleted = false
                    }
                  },
                IsDeleted = false
            };

            List<Sitter> sitters = new List<Sitter>()
            {
                    new Sitter()
                    {
                    Id = 11,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Password = "Password1",
                    WorkTime = new List<WorkTime>()
                    {
                        new WorkTime()
                        {
                            Id = 1,
                            Start = DateTime.Now,
                            End = DateTime.Now,
                            Weekday = Weekday.Sunday
                        }
                    },
                    SubwayStation = new SubwayStation()
                    {
                        Id = 73,
                        Name = "Name1",
                        IsDeleted = false,
                    }
            },

            new Sitter()
            {
                Id = 22,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Password = "Password2",
                WorkTime = new List<WorkTime>(),
                IsDeleted = false
            }

        };

            List<Sitter> expected = new List<Sitter>()
                    {
                    new Sitter()
                    {
                        Id = 11,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        WorkTime = new List<WorkTime>()
                        {
                            new WorkTime()
                            {
                                Id = 11,
                                Start = DateTime.Now,
                                End = DateTime.Now,
                                Weekday = Weekday.Sunday
                            }
                        },
                        SubwayStation = new SubwayStation()
                        {
                            Id = 73,
                            Name = "Name1",
                            Sitters = new List<Sitter>()
                            {
                                new Sitter()
                {
                    Id = 11,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Password = "Password1",
                    WorkTime = new List<WorkTime>()
                    {
                        new WorkTime()
                        {
                            Id = 11,
                            Start = DateTime.Now,
                            End = DateTime.Now,
                            Weekday = Weekday.Sunday
                        }
                    },
                    SubwayStation = new SubwayStation()
                    {
                        Id = 73,
                        Name = "Name1",
                        IsDeleted = false,
                    }
                },

                            },
                            IsDeleted = false

                        }
                    },
        };
            yield return new object[] { subwayStation, sitters, expected };
        }

    }
}



