using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    class GetTestAddressesTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new List<Address>
            {
                new Address{
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = "3",
                Apartament = 1,
                IsDeleted = false
                },
                new Address{
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = "3",
                Apartament = 2,
                IsDeleted = false
                }

            };
            yield return new List<Address>
            {
                new Address{
                Id = 3,
                Name = "TestName3",
                City = "TestCity3",
                Street = "TestStreet3",
                House = "3",
                Apartament = 3,
                IsDeleted = false
                },
                new Address{
                Id = 4,
                Name = "TestName4",
                City = "TestCity4",
                Street = "TestStreet4",
                House = "3",
                Apartament = 4,
                IsDeleted = true
                }

            };
        }
    }
}
