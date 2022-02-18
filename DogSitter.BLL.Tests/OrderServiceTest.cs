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

namespace DogSitter.BLL.Tests
{
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> _orderRepositoryMock;
        private IMapper _mapper;
        private OrderService _service;


        [SetUp]
        public void Setup()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new OrderService(_orderRepositoryMock.Object, _mapper);
        }

        [TestCaseSource(typeof(UpdateOrderTestCaseSource))]
        public void UpdateOrderTest(int id, Order entity, OrderModel model)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(entity);
            _orderRepositoryMock.Setup(x => x.Update(entity, It.IsAny<Order>())).Verifiable();
            //when       
            _service.UpdateOrder(id, model);
            //then            
            _orderRepositoryMock.Verify(x => x.GetById(id), Times.Once);
            _orderRepositoryMock.Verify(x => x.Update(entity, It.IsAny<Order>()), Times.Once);
        }

        [TestCaseSource(typeof(UpdateOrderTestCaseSource))]
        public void UpdateOrderTest_WhenOrderNotFound_ShouldThrowEntityNotFoundExeption(int id, Order entity, OrderModel model)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id));
            _orderRepositoryMock.Setup(x => x.Update(entity, It.IsAny<Order>()));
            //when       

            //then            
            Assert.Throws<EntityNotFoundException>(() => _service.UpdateOrder(id, model));
            _orderRepositoryMock.Verify(x => x.GetById(id));
            _orderRepositoryMock.Verify(x => x.Update(entity, It.IsAny<Order>()), Times.Never);
        }

        [TestCaseSource(typeof(UpdateOrderWhenOrderHasBeenAcceptedTestCaseSource))]
        public void UpdateOrderTest_WhenOrderHasBeenAccepted_ShouldThrowExeption(int id, Order entity, OrderModel model)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(entity);
            _orderRepositoryMock.Setup(x => x.Update(entity, It.IsAny<Order>()));
            //when       

            //then            
            Assert.Throws<Exception>(() => _service.UpdateOrder(id, model));
            _orderRepositoryMock.Verify(x => x.GetById(id), Times.Once);
            _orderRepositoryMock.Verify(x => x.Update(entity, It.IsAny<Order>()), Times.Never);
        }

        [TestCase(1, 2)]
        public void EditOrderStatusByOrderIdTest(int id, int status)
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
