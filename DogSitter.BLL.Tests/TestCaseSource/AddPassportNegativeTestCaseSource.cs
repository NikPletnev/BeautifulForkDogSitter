using DogSitter.BLL.Models;
using System;
using System.Collections;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class AddPassportNegativeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            PassportModel model = new PassportModel()
            {
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
            };

            yield return new object[] { model };

            PassportModel model2 = new PassportModel()
            {
                FirstName = "Мария",
                LastName = "Нефедова",
                DateOfBirth = new DateTime(1234, 11, 1),
                Seria = "1234",
                Number = "",
                IssueDate = new DateTime(1564, 1, 1),
                Division = "МВД по Верхне-услонскому району",
                DivisionCode = "234-567",
                Registration = "г. Иннополис, ул. Спортивная, д. 126, кв. 33",
                IsDeleted = false
            };

            yield return new object[] { model2 };

            PassportModel model3 = new PassportModel()
            {
                Id = 13,
                FirstName = "Денис",
                LastName = "Денискин",
                DateOfBirth = new DateTime(1999, 2, 3),
                Seria = "",
                Number = "876543",
                IssueDate = new DateTime(1976, 5, 23),
                Division = "МВД",
                DivisionCode = "",
                Registration = "г. Казань, ул. Академика Павлова, д. 10, кв. 90",
                IsDeleted = false
            };

            yield return new object[] { model3 };
        }
    }
}