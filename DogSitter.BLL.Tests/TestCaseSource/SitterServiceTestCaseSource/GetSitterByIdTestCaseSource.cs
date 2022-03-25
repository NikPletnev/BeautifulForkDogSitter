using DogSitter.DAL.Entity;
using System;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetSitterByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Sitter sitter =
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
                Passport = new Passport()
                {
                    Id = 4,
                    FirstName = "EqPxa1Sz9xIOePRIlpOgHg==",
                    LastName = "EqPxa1Sz9xIOePRIlpOgHg==",
                    DateOfBirth = new DateTime(1987, 11, 11),
                    Seria = "EqPxa1Sz9xIOePRIlpOgHg==",
                    Number = "EqPxa1Sz9xIOePRIlpOgHg==",
                    IssueDate = new DateTime(1987, 11, 11),
                    Division = "EqPxa1Sz9xIOePRIlpOgHg==",
                    DivisionCode = "EqPxa1Sz9xIOePRIlpOgHg==",
                    Registration = "EqPxa1Sz9xIOePRIlpOgHg==",
                    IsDeleted = false

                }
            };

            yield return new object[] { sitter };
        }
    }
}
