using DogSitter.BLL.Models;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAddressForTestTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var address = new AddressModel
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "1",
                Apartament = 1,
                IsDeleted = false,
            };

            yield return new object[] { address };

        }
    }
}
