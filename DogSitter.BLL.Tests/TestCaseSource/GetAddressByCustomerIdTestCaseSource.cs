using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAddressByCustomerIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id1 = 1;

            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Иван1",
                LastName = "Иванов1",
                Address = new List<Address>()
                {
                    new Address
                    {
                        Id = 1,
                        Name = "Мой дом",
                        City = "Город",
                        Street = "Улица",
                        House = 1,
                        Apartament = 1,
                        IsDeleted = false,
                    },
                    new Address
                    {
                        Id = 2,
                        Name = "Работа",
                        City = "Город",
                        Street = "Улица",
                        House = 2,
                        Apartament = 2,
                        IsDeleted = false,
                    }
                },
                Password = "Ваня1",
                IsDeleted = false,
            };

            List<Address> addresses1 = new List<Address>()
            {
                new Address
                {
                    Id = 1,
                    Name = "Мой дом",
                    City = "Город",
                    Street = "Улица",
                    House = 1,
                    Apartament = 1,
                    IsDeleted = false,
                },
                new Address
                {
                    Id = 2,
                    Name = "Работа",
                    City = "Город",
                    Street = "Улица",
                    House = 2,
                    Apartament = 2,
                    IsDeleted = false,
                }
            };

            yield return new Object[] { id1, customer1, addresses1 };

            int id2 = 2;

            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Иван2",
                LastName = "Иванов2",
                Address = new List<Address>()
                {
                    new Address
                    {
                        Id = 3,
                        Name = "ДомДом",
                        City = "Город",
                        Street = "Улица",
                        House = 3,
                        Apartament = 3,
                        IsDeleted = false,
                    }
                },
                Password = "Ваня2",
                IsDeleted = false,
            };

            List<Address> addresses2 = new List<Address>()
            {
                new Address
                {
                    Id = 3,
                    Name = "ДомДом",
                    City = "Город",
                    Street = "Улица",
                    House = 3,
                    Apartament = 3,
                    IsDeleted = false,
                }
            };

            yield return new Object[] { id2, customer2, addresses2 };

            int id3 = 3;

            Customer customer3 = new Customer()
            {
                Id = 3,
                FirstName = "Иван3",
                LastName = "Иванов3",
                Address = new List<Address>() { },
                Password = "Ваня3",
                IsDeleted = false,
            };

            List<Address> addresses3 = new List<Address>() { };

            yield return new Object[] { id3, customer3, addresses3 };

            int id4 = 4;

            Customer customer4 = new Customer()
            {
                Id = 4,
                FirstName = "Иван4",
                LastName = "Иванов4",
                Address = new List<Address>()
                {
                    new Address
                    {
                        Id = 5,
                        Name = "TestName3",
                        City = "TestCity3",
                        Street = "TestStreet3",
                        House = 3,
                        Apartament = 3,
                        IsDeleted = true,
                    }
                },
                Password = "Ваня4",
                IsDeleted = false,
            };

            yield return new Object[] { id4, customer4, addresses3 };
        }
    }
}