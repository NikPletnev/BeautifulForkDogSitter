using DogSitter.DAL.Entity;
using System;
using System.Collections;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class TimesheetGetByTestCaseSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var Id = 1;
            var timesheet = new Timesheet()
            {
                Id = 1,
                Start = DateTime.Now,
                End = DateTime.Now,
                Weekday = Weekday.Sunday,
                IsDeleted = false
            };

            yield return new Object[] { Id, timesheet };

            Id = 2;
            timesheet = new Timesheet()
            {
                Id = 2,
                Start = DateTime.Now,
                End = DateTime.Now,
                Weekday = Weekday.Saturday,
                IsDeleted = false
            };

            yield return new Object[] { Id, timesheet };
        }
    }
}
