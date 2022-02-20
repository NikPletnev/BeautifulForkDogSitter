using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class WorkTimeTestCaseSourse
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
                    Sitter = new Sitter(),
                    IsDeleted = false
                },

                new WorkTime()
                {
                    Id = 2,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Saturday,
                    Sitter = new Sitter(),
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
                    Sitter = new Sitter(),
                    IsDeleted = false
                };
    }
}
