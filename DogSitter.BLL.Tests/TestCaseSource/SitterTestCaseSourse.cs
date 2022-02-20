using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                IsDeleted = false
            };
        public static SitterModel GetMockSitterModel() =>
            new SitterModel()
            {
                Id = 4,
                FirstName = "Флюго",
                LastName = "Хьюгер",
                Password = "hug123",
                Information = "SITTERs DEVIL",
                IsDeleted = false
            };
    }
}
