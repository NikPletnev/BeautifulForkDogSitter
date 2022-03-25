using DogSitter.DAL.Entity;
using System;
using System.Collections;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class GetAddressByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {

            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Иван1",
                LastName = "Иванов1",
                Address =
                    new Address
                    {
                        Id = 1,
                        Name = "Мой дом",
                        City = "Город",
                        Street = "Улица",
                        House = "3",
                        Apartament = 1,
                        IsDeleted = false,
                    }

                ,
                Password = "Ваня1",
                IsDeleted = false,
            };

            Address addresses1 =
                new Address
                {
                    Id = 1,
                    Name = "Мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = "3",
                    Apartament = 1,
                    IsDeleted = false,
                };

            yield return new Object[] { customer1, addresses1 };

            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Address =
                    new Address
                    {
                        Id = 3,
                        Name = "ДомДом",
                        City = "Город",
                        Street = "Улица",
                        House = "3",
                        Apartament = 3,
                        IsDeleted = false,
                    }
                ,
                Password = "Ваня2",
                IsDeleted = false,
            };

            Address addresses2 =
                new Address
                {
                    Id = 3,
                    Name = "ДомДом",
                    City = "Город",
                    Street = "Улица",
                    House = "3",
                    Apartament = 3,
                    IsDeleted = false,
                }
            ;

            yield return new Object[] { customer2, addresses2 };

            Customer customer3 = new Customer()
            {
                Id = 3,
                FirstName = "Иван3",
                LastName = "Иванов3",
                Address = null,
                Password = "Ваня3",
                IsDeleted = false,
            };

            Address addresses3 = null;

            yield return new Object[] { customer3, addresses3 };

            Customer customer4 = new Customer()
            {
                Id = 4,
                FirstName = "Иван4",
                LastName = "Иванов4",
                Address =
                    new Address
                    {
                        Id = 5,
                        Name = "TestName3",
                        City = "TestCity3",
                        Street = "TestStreet3",
                        House = "3",
                        Apartament = 3,
                        IsDeleted = true,
                    }
                ,
                Password = "Ваня4",
                IsDeleted = false,
            };

            Address address4 =
            new Address
            {
                Id = 5,
                Name = "TestName3",
                City = "TestCity3",
                Street = "TestStreet3",
                House = "3",
                Apartament = 3,
                IsDeleted = true,
            };

            yield return new Object[] { customer4, address4 };
        }
    }
}
