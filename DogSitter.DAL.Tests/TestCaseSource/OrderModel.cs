using System;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    internal class OrderModel
    {
        public OrderModel()
        {
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public object Status { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}