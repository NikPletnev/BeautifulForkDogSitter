using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class ServiceTestMock
    {
        public List<Serviсe> GetMockServices() =>
            new List<Serviсe>()
            {
                new Serviсe()
                {
                    Id = 1,
                    Name = "Name1",
                    Description = "Description1",
                    Price = 1000m,
                    DurationHours = 1.0,
                    IsDeleted = false
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

        public Serviсe GetMockService() =>
                new Serviсe()
                {
                    Id = 3,
                    Name = "Name3",
                    Description = "Description3",
                    Price = 3000m,
                    DurationHours = 3.0,
                    IsDeleted = false
                };
    }
}

