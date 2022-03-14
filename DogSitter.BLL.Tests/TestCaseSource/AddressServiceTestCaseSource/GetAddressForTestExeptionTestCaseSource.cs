using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAddressForTestExeptionTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var addressWithNoName = new AddressModel
            {
                Name = "",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            var addressWithNoCity = new AddressModel
            {
                Name = "TestName",
                City = "",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            var addressWithNoStreet = new AddressModel
            {
                Name = "TestName",
                City = "TestCity",
                Street = "",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            var addressWithNoHouse = new AddressModel
            {
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            var addressWithNoApartament = new AddressModel
            {
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "0",
                Apartament = 0,
                IsDeleted = false,
            };

            var addressEntity = new Address
            {
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            yield return new object[] { addressWithNoName, addressEntity };
            yield return new object[] { addressWithNoStreet, addressEntity };
            yield return new object[] { addressWithNoHouse, addressEntity };
            yield return new object[] { addressWithNoApartament, addressEntity };

        }
    }
}
