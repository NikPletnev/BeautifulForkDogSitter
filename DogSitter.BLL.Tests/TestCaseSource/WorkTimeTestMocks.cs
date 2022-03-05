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
                    Sitter = new Sitter()
                    {
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        Contacts = new List<Contact>(),
                        IsDeleted = false
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
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        Contacts = new List<Contact>(),
                        IsDeleted = false
                    },
                    IsDeleted = true
                }
            };

        public WorkTime GetMockWorkTime() =>
                new WorkTime()
                {
                    Id = 77,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Weekday = Weekday.Saturday,
                    Sitter = new Sitter()
                    {
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1",
                        Contacts = new List<Contact>(),
                        IsDeleted = false
                    },
                    IsDeleted = false
                };
    }
}
