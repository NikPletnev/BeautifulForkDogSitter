using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly IMapper _mapper;
        private  OrderService _service;
        private OrderTestCaseSourse _orderMock;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
        }

        [SetUp]
        public void SetUp()
        {
            _service = new OrderService(_orderRepositoryMock.Object, _mapper);
            _orderMock = new OrderTestCaseSourse();
        }

        [Test]
        public void GetAllOrders_ShouldReturnOrders()
        {
            var expected = _orderMock.GetOrders();
            _orderRepositoryMock.Setup(x => x.GetAll()).Returns(expected);

            var actual = _service.GetAll();


            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            _orderRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [Test]
        public void GetOrderByIdTest()
        {
            var expected = _orderMock.GetOrder();
            _orderRepositoryMock.Setup(m => m.GetById(expected.Id)).Returns(expected);

            var actual = _service.GetById(4);

            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Id, expected.Id);
            Assert.AreEqual(actual.OrderDate, expected.OrderDate);
            Assert.AreEqual(actual.Price, expected.Price);
            Assert.AreEqual(actual.Mark, expected.Mark);
            _orderRepositoryMock.Verify(m => m.GetById(expected.Id));
        }

        [Test]
        public void GetOrderByIdNegativeTest()
        {
            _orderRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Order)null);

            Assert.Throws<EntityNotFoundException>(() => _service.GetById(0));
        }

        [Test]
        public void AddOrderTest()
        {
            _orderRepositoryMock.Setup(m => m.Add(It.IsAny<Order>()));
            var orderModel = _orderMock.GetOrderModel();

            _service.Add(orderModel);

            _orderRepositoryMock.Verify(m => m.Add(It.IsAny<Order>()), Times.Once);
        }

        [Test]
        public void UpdateOrderTest()
        {
            var expected = _orderMock.GetOrderModel();
            _orderRepositoryMock.Setup(x => x.GetById(expected.Id)).Returns(It.IsAny<Order>());

            Assert.Throws<EntityNotFoundException>(() => _service.Update(expected));
        }

        [Test]
        public void UpdateOrderNegativeTest()
        {
            var expected = _orderMock.GetOrderModel();
            expected.Id = 0;
            _orderRepositoryMock.Setup(x => x.GetById(expected.Id)).Returns(It.IsAny<Order>());

            Assert.Throws<EntityNotFoundException>(() => _service.Update(expected));
        }

        [Test]
        public void DeleteOrderTest()
        {
            _orderRepositoryMock.Setup(m => m.Update(It.IsAny<Order>()));
            _orderRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Order());

            _service.DeleteById(new OrderModel());

            _orderRepositoryMock.Verify(m => m.Update(It.IsAny<Order>()), Times.Never());
            _orderRepositoryMock.Verify(m => m.Update(It.IsAny<Order>(), It.IsAny<bool>()));
        }

        [Test]
        public void DeleteOrderNegativeTest()
        {
            _orderRepositoryMock.Setup(m => m.Update(It.IsAny<Order>(), It.IsAny<bool>()));
            _orderRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Order)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteById(new OrderModel()));
        }

        [Test]
        public void RestoreOrderTest()
        {
            _orderRepositoryMock.Setup(m => m.Update(It.IsAny<Order>(), true));
            _orderRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Order());

            _service.Restore(new OrderModel() { Id = 2});

            //then
            _orderRepositoryMock.Verify(m => m.Update(It.IsAny<Order>(), false), Times.Once());
        }

        [Test]
        public void RestoreOrderNegativeTest()
        {
            _orderRepositoryMock.Setup(m => m.Update(It.IsAny<Order>(), It.IsAny<bool>()));
            _orderRepositoryMock.Setup(m => m.GetById(It.IsAny<int>())).Returns((Order)null);

            Assert.Throws<EntityNotFoundException>(() => _service.DeleteById(new OrderModel()));
        }

        [TestCase(1, 2)]
        public void EditOrderStatusByOrderIdTest(int id, int status)
        {
            //given
            var order = _orderMock.EditOrderStatusByOrderId();
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(order);
            _orderRepositoryMock.Setup(x => x.EditOrderStatusByOrderId(order, status));
            //when
            _service.EditOrderStatusByOrderId(id, status);
            //then
            _orderRepositoryMock.Verify(x => x.GetById(id));
            _orderRepositoryMock.Verify(x => x.EditOrderStatusByOrderId(order, status), Times.Once);

        }

        [TestCase(1, 3)]
        public void EditOrderStatusByOrderIdTest_WhenOrderNotFound_ShouldThrowEntityNotFoundException(int id, int status)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.EditOrderStatusByOrderId(id, status));
        }
    }
}
