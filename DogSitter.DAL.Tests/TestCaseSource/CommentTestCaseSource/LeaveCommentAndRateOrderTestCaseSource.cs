using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class LeaveCommentAndRateOrderTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var order = new Order()
            {
                Id = 22,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Created,
                Mark = 5,
                Comment = new Comment() { Id = 23, Text = "All right", Date = new DateTime(2000, 11, 11), IsDeleted = false },
                IsDeleted = false
            };

            var dbOrder = new Order()
            {
                Id = 22,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Created,
                IsDeleted = false
            };




            yield return new object[] { dbOrder, order };
        }
    }
}
