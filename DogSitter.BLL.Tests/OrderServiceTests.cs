using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
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
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CustomMapper>()));
            _service = new OrderService(_orderRepositoryMock.Object, _mapper);
        }

        [TestCase(1, 2)]
        public void EditOrderStatusByOrderIdTest(int id, int status)
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
