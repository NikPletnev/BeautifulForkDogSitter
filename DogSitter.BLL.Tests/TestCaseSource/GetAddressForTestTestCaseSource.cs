using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAddressForTestTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var address = new AddressModel
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false,
            };

            yield return new object[] { address };

        }
    }
}
