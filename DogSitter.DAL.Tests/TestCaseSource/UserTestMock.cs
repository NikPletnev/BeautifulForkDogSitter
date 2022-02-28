using DogSitter.DAL.Entity;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class UserTestMock
    {
        public static List<User> GetUsers() =>
            new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Password = "12345",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    IsDeleted = false
                },
                new User()
                {
                    Id = 2,
                    Password = "54321",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    IsDeleted = false
                },
            };

    }
}

