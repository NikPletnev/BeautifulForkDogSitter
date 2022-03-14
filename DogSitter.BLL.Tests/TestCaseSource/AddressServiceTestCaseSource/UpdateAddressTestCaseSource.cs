using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class UpdateAddressTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var address = new Address
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            var addressToUpdate = new AddressModel
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };



            yield return new object[] { address, addressToUpdate };

        }
    }
}
