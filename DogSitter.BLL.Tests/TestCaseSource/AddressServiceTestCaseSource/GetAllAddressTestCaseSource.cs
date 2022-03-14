using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;


namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllAddressTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var addreses = new List<Address>
            {
                new Address{
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
                SubwayStations = new List<SubwayStation>() { }
                },
                new Address{
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = "1",
                Apartament = 2,
                IsDeleted = false,
                SubwayStations = new List<SubwayStation>() { }
                }

            };

            var expected = new List<AddressModel>
            {
                new AddressModel{
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
                SubwayStations = new List<SubwayStationModel>() { }
                },
                new AddressModel{
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = "1",
                Apartament = 2,
                IsDeleted = false,
                SubwayStations = new List<SubwayStationModel>() { }
                }

            };


            yield return new object[] { addreses, expected };

        }
    }
}
