using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class OrderRepositoryTests
    {
        private DogSitterContext _context;
        private OrderRepository _rep;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase("OrderTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _rep = new OrderRepository(_context);
        }

        [TestCase(1, 2)]
        public void EditOrderStatusByOrderId(int id, int status)
        {
            //given
            var order = new Order()
            {
                Id = 1,
                OrderDate = new DateTime(2011, 11, 11),
                Status = Status.Created,
                CommentId = 1,
                Price = 100,
                IsDeleted = false
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            //when
            _rep.EditOrderStatusByOrderId(order, status);
            var actual = _context.Orders.FirstOrDefault(x => x.Id == id);

            //then
            Assert.AreEqual((Status)status, actual.Status);

        }

        [TestCaseSource(typeof(GetAllOrdersBySitterIdTestCaseSource))]
        public void GetAllOrdersBySitterIdTest(int id, List<Sitter> sitters, List<Order> expected)
        {
            //given
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();

            //when
            var actual = _rep.GetAllOrdersBySitterId(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(GetAllOrdersByCustomerIdTestCaseSource))]
        public void GetAllOrdersByCustomerId(int id, List<Customer> customers, List<Order> expected)
        {
            //given
            _context.Customers.AddRange(customers);
            _context.SaveChanges();

            //when
            var actual = _rep.GetAllOrdersByCustomerId(id);

            //then
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(LeaveCommentAndRateOrderTestCaseSource))]
        public void LeaveCommentAndRateOrderTest(Order order, Order ratedOrder)
        {
            //given
            _context.Orders.Add(order);
            _context.SaveChanges();
            var expected = ratedOrder;

            //when
            _rep.LeaveCommentAndRateOrder(order, ratedOrder);
            var actual = _context.Orders.FirstOrDefault(z => z.Id == 1);

            //then

            Assert.AreEqual(expected.Comment , actual.Comment);
            Assert.AreEqual(expected.Mark, actual.Mark);
        }
    }
}
