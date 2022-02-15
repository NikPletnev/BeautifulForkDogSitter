using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
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
                Status = Status.created,
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
    }
}
