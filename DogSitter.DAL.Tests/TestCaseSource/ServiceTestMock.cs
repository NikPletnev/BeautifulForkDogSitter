using DogSitter.DAL.Entity;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public static class ServiceTestMock
    {
        public static List<Serviсe> GetServices() =>
            new List<Serviсe>()
            {
                new Serviсe()
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1000m,
                    DurationHours = 1.0,
                    IsDeleted = false,
                    Sitter = new Sitter()
                {
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Password = "Password1"
                }
                },

                new Serviсe()
                {
                    Id = 2,
                    Name = "Name2",
                    Description = "Description2",
                    Price = 2000m,
                    DurationHours = 2.0,
                    IsDeleted = true
                }
            };

        public static Serviсe GetService() =>
                new Serviсe()
                {
                    Id = 3,
                    Name = "Name3",
                    Description = "Description3",
                    Price = 3000m,
                    DurationHours = 3.0,
                    IsDeleted = false,
                    Orders = new List<Order>(),
                    Sitter = new Sitter()
                    {
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Password = "Password1"
                    }
                };
    }
}



