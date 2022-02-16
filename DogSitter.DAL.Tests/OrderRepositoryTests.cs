using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using DogSitter.DAL.Tests.TestCaseSource;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _repository.Add(expected);
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
        public void UodateOrderTest()
        {
            var order = OrderTestCaseSourse.GetOrder();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var expected = new Order()
            {
                Id = 3,
                OrderDate = DateTime.Now,
                Status = Status.completed,
                Price = 100,
                IsDeleted = false
            };
            _repository.Add(OrderTestCaseSourse.GetEditOrderStatus());
            _repository.Update(expected);
            var actual = _context.Orders.First(x => x.Id == order.Id);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        [Test]
        public void UpdateIsDeleteOrderTest()
        {
            var order = OrderTestCaseSourse.GetOrder();

            _repository.Update(order, true);

            Assert.AreEqual(order.IsDeleted, true);
        }

        [Test]
        public void RestoreOrderTest()
        {
            var order = OrderTestCaseSourse.GetOrder();

            _repository.Update(order, false);

            Assert.AreEqual(order.IsDeleted, false);
        }

        [TestCase(4, 2)]
        public void EditOrderStatusByOrderId(int id, int status)
        {
            //given
            var order = OrderTestCaseSourse.GetEditOrderStatus();

            _context.Orders.Add(order);
            _context.SaveChanges();

            //when
            _repository.EditOrderStatusByOrderId(order, status);
            var actual = _context.Orders.FirstOrDefault(x => x.Id == id);

            //then
            Assert.AreEqual((Status)status, actual.Status);

        }
    }
}
