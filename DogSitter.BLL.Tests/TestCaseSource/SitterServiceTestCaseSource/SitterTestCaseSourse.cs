using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class SitterTestCaseSourse
    {
        public static List<Sitter> GetMockSitters() =>
           new List<Sitter>()
           {
                new Sitter()
                {
                    Id = 1,
                    FirstName ="Иннокентий",
                    LastName ="Пипидастров",
                    Password = "qwe123",
                    Information ="GOOD SITTER",
                    AddressId = 1,
                    PassportId = 1,
                    IsDeleted = false
                },
                new Sitter()
                {
                    Id = 2,
                    FirstName ="Иван",
                    LastName ="Хренов",
                    Password = "123qwe",
                    Information ="BAD SITTER",
                    AddressId = 2,
                    PassportId = 2,
                    IsDeleted = true
                }
           };
        public static Sitter GetMockSitter() =>
            new Sitter()
            {
                Id = 3,
                FirstName = "Хьюго",
                LastName = "Флюгер",
                Password = "flug123",
                Information = "SITTERs GOD",
                AddressId = 3,
                PassportId = 3,
                IsDeleted = false,
                SubwayStation = new SubwayStation() { Id = 1 },
                Passport = new Passport()
                {
                    Id = 4,
                    FirstName = "Хьюго",
                    LastName = "Флюгер",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Seria = "4556",
                    Number = "123456",
                    IssueDate = new DateTime(1987, 11, 11),
                    Division = "МВД по РТ",
                    DivisionCode = "160-098",
                    Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                    IsDeleted = false
                }
            };
        public static Sitter GetMockSitterToUpdate() =>
            new Sitter()
            {
                Id = 3,
                FirstName = "Хьюго",
                LastName = "Флюгер",
                Password = "flug123",
                Information = "SITTERs GOD",
                AddressId = 3,
                PassportId = 3,
                IsDeleted = false,
                SubwayStation = new SubwayStation() { Id = 2 },
                Passport = new Passport()
                {
                    Id = 4,
                    FirstName = "Хьюго",
                    LastName = "Флюгер",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Seria = "4556",
                    Number = "123456",
                    IssueDate = new DateTime(1987, 11, 11),
                    Division = "МВД по РТ",
                    DivisionCode = "160-098",
                    Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                    IsDeleted = false
                }
            };
        public static SitterModel GetMockSitterModel() =>
            new SitterModel()
            {
                Id = 4,
                FirstName = "Флюго",
                LastName = "Хьюгер",
                Password = "hug123",
                Information = "SITTERs DEVIL",
                IsDeleted = false,
                SubwayStation = new SubwayStationModel() { Id = 1 },
                Passport = new PassportModel()
                {
                    Id = 4,
                    FirstName = "",
                    LastName = "Иван",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Seria = "4556",
                    Number = "123456",
                    IssueDate = new DateTime(1987, 11, 11),
                    Division = "МВД по РТ",
                    DivisionCode = "160-098",
                    Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                    IsDeleted = false

                }
            };
    }
}
