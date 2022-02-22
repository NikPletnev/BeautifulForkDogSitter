using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class WorkTimeMock
    {
        public static List<WorkTime> GetWorkTimes() =>
            new List<WorkTime>()
            {
                new WorkTime()
                {
                    Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Sunday,
                    Sitter = new Sitter()
                    {
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1"
                    },
                    IsDeleted = false
                },

                new WorkTime()
                {
                    Id = 2,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Saturday,
                    Sitter = new Sitter()
                    {
                        FirstName = "FirstName2",
                        LastName = "LastName2",
                        Password = "Password2",
                    },
                    IsDeleted = true
                }
            };

        public static WorkTime GetWorkTime() =>
                new WorkTime()
                {
                    Id = 3,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow,
                    Weekday = Weekday.Saturday,
                    Sitter = new Sitter()
                    {
                        FirstName = "FirstName3",
                        LastName = "LastName3",
                        Password = "Password3",
                    },
                    IsDeleted = false
                };
    }
}
