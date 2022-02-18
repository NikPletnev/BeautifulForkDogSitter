using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class UpdateOrderTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 2;

            Order order = new Order()
            {
                Id = 2,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                CommentId = 1,
                Price = 100,
                IsDeleted = false
            };

            OrderModel model = new OrderModel()
            {
                Id = 2,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                Price = 100,
                IsDeleted = false
            };

            yield return new object[] { id, order, model};
        }
    }
}
