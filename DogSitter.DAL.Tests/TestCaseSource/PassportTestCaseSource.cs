using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class PassportTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Passport> passports = new List<Passport>() {
              new Passport()
                {
                  FirstName = "Иванов",
                  LastName = "Иван",
                  DateOfBirth = new DateTime( 1987, 11, 11),
                  Seria = "4556",
                  Number = "123456",
                  IssueDate = new DateTime( 1987, 11, 11),
                  Division = "МВД по РТ",
                  DivisionCode = "160-098",
                  Registration = "г. Казань, ул. Фучика, д. 45, кв. 4",
                  IsDeleted = false
                },
              new Passport()
                {
                  FirstName = "Мария",
                  LastName = "Нефедова",
                  DateOfBirth = new DateTime(1234, 11, 1),
                  Seria = "1234",
                  Number = "567890",
                  IssueDate = new DateTime(1564, 1, 1),
                  Division = "МВД по Верхне-услонскому району",
                  DivisionCode = "234-567",
                  Registration = "г. Иннополис, ул. Спортивная, д. 126, кв. 33",
                  IsDeleted = false
                },
              new Passport()
                {
                  FirstName = "Денис",
                  LastName = "Денискин",
                  DateOfBirth = new DateTime(1999, 2, 3),
                  Seria = "3456",
                  Number = "876543",
                  IssueDate = new DateTime(1976, 5, 23),
                  Division = "МВД",
                  DivisionCode = "345-555",
                  Registration = "г. Казань, ул. Академика Павлова, д. 10, кв. 90",
                  IsDeleted = false
                } };

            yield return new object[] { passports };
        }
    }
}
