using DogSitter.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class SitterTestCaseSourse
    {
        public static List<Sitter> GetSitters() =>
            new List<Sitter>()
            {
                new Sitter()
                {
                    Id = 1,
                    FirstName ="Иннокентий",
                    LastName ="Пипидастров",
                    Password = "qwe123",
                    Information ="GOOD SITTER",
                    Verified = true,
                    IsDeleted = false
                },
                new Sitter()
                {
                    Id = 2,
                    FirstName ="Иван",
                    LastName ="Хренов",
                    Password = "123qwe",
                    Information ="BAD SITTER",
                    Verified = false,
                    IsDeleted = true
                }
            };
        public static Sitter GetSitter() =>
            new Sitter()
            {
                Id = 3,
                FirstName = "Хьюго",
                LastName = "Флюгер",
                Password = "flug123",
                Information = "SITTERs GOD",
                Verified = true,
                IsDeleted = false
            };
    }
}
