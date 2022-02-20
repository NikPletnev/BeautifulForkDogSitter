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
                    IsDeleted = false
                },

                new SubwayStation()
                {
                    Id = 2,
                    Name = "Name2",
                    IsDeleted = true
                }
             };

        public SubwayStation GetSubwayStation() =>
                new SubwayStation()
                {
                    Id = 3,
                    Name = "Name3",
                    IsDeleted = false
                };

        public SubwayStationModel GetSubwayStationModel() =>
        new SubwayStationModel()
        {
            Id = 3,
            Name = "Name3"
        };
    }
}
