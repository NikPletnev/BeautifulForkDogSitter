using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DogSitter.DAL.Tests
{
    public class OrderRepositoryTests
    {
        private DogSitterContext _context;
        private OrderRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DogSitterContext>()
                .UseInMemoryDatabase(databaseName: "OrderTestDB")
                .Options;

            _context = new DogSitterContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new OrderRepository(_context);

            var orders = OrderTestCaseSourse.GetOrders();
            _context.Orders.AddRange(orders);

            _context.SaveChanges();
        }

        [Test]
        public void AddOrderTest()
        {
            var expected = OrderTestCaseSourse.GetOrder();
            var cust = new Customer()
            {
                FirstName = "FirstName1",
                LastName = "LastName1",
                Password = "Password1"
            };

            _repository.Add(expected, cust);
            var actual = _context.Orders.FirstOrDefault(x => x.Id == expected.Id);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetOrderByIdTests(int id)
        {
            var expected = _context.Orders.Find(id);

            var actual = _repository.GetById(id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrdersTest()
        {
            var expected = _context.Orders.Where(e => !e.IsDeleted);

            var actual = _repository.GetAll();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Where(e => e.IsDeleted), actual.Where(a => a.IsDeleted));
        }

        [Test]
        public void UpdateOrderTest()
        {
            var order = OrderTestCaseSourse.GetOrderByUpdate();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var expected = new Order()
            {
                Id = 3,
                OrderDate = order.OrderDate,
                Price = 303,
                Status = Status.Created,
                Mark = 1,
                Sitter = new Sitter()
                {
                    Id = 33,
                    FirstName = " ",
                    LastName = " ",
                    Password = " "
                },
                Comment = new Comment()
                {
                    Text = " "
                },
                IsDeleted = false
            };
            _repository.Update(order);
            var actual = _context.Orders.First(x => x.Id == order.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Mark, actual.Mark);
            Assert.AreEqual(expected.Sitter, actual.Sitter);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [Test]
        public void UpdateIsDeleteOrderTest()
        {
            var order = OrderTestCaseSourse.GetOrder();
            _context.Orders.Add(order);
            _context.SaveChanges();

            _repository.Update(order, true);
            Assert.AreEqual(order.IsDeleted, true);
        }

        [TestCase(3)]
        public void RestoreOrderTest(int id)
        {
            var order = OrderTestCaseSourse.GetOrder();
            _context.Orders.Add(order);
            _context.SaveChanges();

            _repository.Update(order, false);
            var actual = OrderTestCaseSourse.GetOrder();
            Assert.AreEqual(actual.IsDeleted, false);
        }

        [TestCase(2)]
        public void EditOrderStatusByOrderId(int status)
        {
            //given
            var order = OrderTestCaseSourse.GetEditOrderStatus();

            _context.Orders.Add(order);
            _context.SaveChanges();

            //when
            _repository.EditOrderStatusByOrderId(order, status);
            var actual = _context.Orders.FirstOrDefault(x => x.Id == order.Id);

            //then
            Assert.AreEqual(actual, order);
        }

        [TestCaseSource(typeof(GetAllOrdersBySitterIdTestCaseSource))]
        public void GetAllOrdersBySitterIdTest(int id, List<Sitter> sitters, List<Order> expected)
        {
            //given
            _context.Sitters.AddRange(sitters);
            _context.SaveChanges();

            //when
            var actual = _repository.GetAllOrdersBySitterId(id);

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
            var actual = _repository.GetAllOrdersByCustomerId(id);

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
            _repository.LeaveCommentAndRateOrder(order, ratedOrder);
            var actual = _context.Orders.FirstOrDefault(z => z.Id == order.Id);

            //then

            Assert.AreEqual(expected.Comment, actual.Comment);
            Assert.AreEqual(expected.Mark, actual.Mark);
        }
    }
}
