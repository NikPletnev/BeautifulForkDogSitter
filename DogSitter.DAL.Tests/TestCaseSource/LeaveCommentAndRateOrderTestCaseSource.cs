﻿using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class LeaveCommentAndRateOrderTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var order = new Order()
            {
                Id = 1,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Created,
                Mark = 5,
                Comment = new Comment() { Id = 1, Text = "All right", Date = new DateTime(2000,11,11), IsDeleted = false },
                IsDeleted = false
            };

            var dbOrder = new Order()
            {
                Id = 1,
                OrderDate = new DateTime(2011, 11, 11),
                Price = 100,
                Status = Status.Created,
                IsDeleted = false
            };

  


            yield return new object[] { dbOrder, order };
        }
    }
}
