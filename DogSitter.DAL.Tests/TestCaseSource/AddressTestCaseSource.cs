﻿using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    class GetTestAddressTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Address
            {
                Id = 1,
                Name = "TestName",
                City = "TestCity",
                Street = "TestStreet",
                House = 1,
                Apartament = 1,
                IsDeleted = false,
            };
            yield return new Address
            {
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = 2,
                Apartament = 2,
                IsDeleted = false,
            };
            yield return new Address
            {
                Id = 3,
                Name = "TestName3",
                City = "TestCity3",
                Street = "TestStreet3",
                House = 3,
                Apartament = 3,
                IsDeleted = true,
            };
        }
    }
}
