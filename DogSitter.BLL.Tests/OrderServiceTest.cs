using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.BLL.Tests.TestCaseSource;
using DogSitter.DAL.Entity;
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
        private readonly OrderService _service;

        public OrderServiceTests()
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

    }
}
