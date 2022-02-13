using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class WorkTimeTestMocks
    {
        public List<WorkTime> GetMockWorkTimes() =>
            new List<WorkTime>()
            {
                new WorkTime()
                {
                    Id = 1,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Sunday,
                    Sitter = new List<Sitter>(),
                    IsDeleted = false
                },

                new WorkTime()
                {
                    Id = 2,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Saturday,
                    Sitter = new List<Sitter>(),
                    IsDeleted = true
                }
            };

        public WorkTime GetMockWorkTime() =>
                new WorkTime()
                {
                    Id = 3,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Saturday,
                    Sitter = new List<Sitter>(),
                    IsDeleted = false
                };
    }
}
