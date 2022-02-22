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

namespace DogSitter.BLL.Tests
{
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<ICustomerRepository> _customerRepMock;
        private Mock<ISitterRepository> _sitterRepMock;
        private Mock<IUserRepository> _userRepMock;
        private IMapper _mapper;
        private OrderService _service;


        [SetUp]
        public void Setup()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _customerRepMock = new Mock<ICustomerRepository>();
            _sitterRepMock = new Mock<ISitterRepository>();
            _userRepMock = new Mock<IUserRepository>();

            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>()));
            _service = new OrderService(_orderRepositoryMock.Object, _customerRepMock.Object, _sitterRepMock.Object, _mapper, _userRepMock.Object);
        }

        [TestCaseSource(typeof(UpdateOrderTestCaseSource))]
        public void UpdateOrderTest(int id, Order entity, OrderModel model)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(entity);
            _orderRepositoryMock.Setup(x => x.Update(entity, It.IsAny<Order>())).Verifiable();
            _userRepMock.Setup(x => x.GetUserById(entity.Customer.Id)).Returns(entity.Customer);
            //when       
            _service.Update(entity.Customer.Id, model);
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
            _userRepMock.Setup(x => x.GetUserById(entity.Customer.Id)).Returns(entity.Customer);
            //when       

            //then            
            Assert.Throws<EntityNotFoundException>(() => _service.Update(entity.Customer.Id, model));
            _orderRepositoryMock.Verify(x => x.GetById(id));
            _orderRepositoryMock.Verify(x => x.Update(entity, It.IsAny<Order>()), Times.Never);
        }

        [TestCaseSource(typeof(UpdateOrderWhenOrderHasBeenAcceptedTestCaseSource))]
        public void UpdateOrderTest_WhenOrderHasBeenAccepted_ShouldThrowExeption(int id, Order entity, OrderModel model)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(entity);
            _orderRepositoryMock.Setup(x => x.Update(entity, It.IsAny<Order>()));
            _userRepMock.Setup(x => x.GetUserById(entity.Customer.Id)).Returns(entity.Customer);
            //when       

            //then            
            Assert.Throws<Exception>(() => _service.Update(entity.Customer.Id, model));
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
                IsDeleted = false,
                Customer = new Customer()
                {
                    Id = 1,
                    FirstName = "qqq",
                    LastName = "www",
                    Password = "1234"
                }

            };
            _orderRepositoryMock.Setup(x => x.GetById(id)).Returns(order);
            _orderRepositoryMock.Setup(x => x.EditOrderStatusByOrderId(order, status));
            _userRepMock.Setup(x => x.GetUserById(order.Customer.Id)).Returns(order.Customer);
            //when
            _service.EditOrderStatusByOrderId(order.Customer.Id, id, status);
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
            Assert.Throws<EntityNotFoundException>(() => _service.EditOrderStatusByOrderId(It.IsAny<int>(), id, status));
        }

        [TestCaseSource(typeof(GetAllOrdersBySitterIdTestCaseSource))]
        public void GetAllOrdersBySitterId(int id, Sitter sitter, List<Order> orders)
        {
            //given
            _sitterRepMock.Setup(x => x.GetById(id)).Returns(sitter);
            _orderRepositoryMock.Setup(x => x.GetAllOrdersBySitterId(id)).Returns(orders);
            _userRepMock.Setup(x => x.GetUserById(id)).Returns(sitter);
            //when
            var actual = _service.GetAllOrdersBySitterId(sitter.Id, id);
            //then
            _sitterRepMock.Verify(x => x.GetById(id));
            _orderRepositoryMock.Verify(x => x.GetAllOrdersBySitterId(id), Times.Once);
        }

        [TestCase(1)]
        public void GetAllOrdersBySitterId_WhenSitterNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _sitterRepMock.Setup(x => x.GetById(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetAllOrdersBySitterId(It.IsAny<int>(), id));
            _sitterRepMock.Verify(x => x.GetById(id));
            _orderRepositoryMock.Verify(x => x.GetAllOrdersBySitterId(id), Times.Never);
        }

        [TestCaseSource(typeof(GetAllOrdersByCustomerIdTestCaseSource))]
        public void GetAllOrdersByCustomerId(int id, Customer customer, List<Order> orders)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id)).Returns(customer);
            _orderRepositoryMock.Setup(x => x.GetAllOrdersByCustomerId(id)).Returns(orders);
            _userRepMock.Setup(x => x.GetUserById(customer.Id)).Returns(customer);
            //when
            var actual = _service.GetAllOrdersByCustomerId(customer.Id, id);
            //then
            _customerRepMock.Verify(x => x.GetCustomerById(id));
            _orderRepositoryMock.Verify(x => x.GetAllOrdersByCustomerId(id), Times.Once);
        }

        [TestCase(1)]
        public void GetAllOrdersByCustomerId_WhenCustomerNotFound_ShouldThrowEntityNotFoundException(int id)
        {
            //given
            _customerRepMock.Setup(x => x.GetCustomerById(id));
            _orderRepositoryMock.Setup(x => x.GetAllOrdersByCustomerId(id));
            //when
            //then
            Assert.Throws<EntityNotFoundException>(() => _service.GetAllOrdersByCustomerId(It.IsAny<int>(), id));
            _customerRepMock.Verify(x => x.GetCustomerById(id));
            _orderRepositoryMock.Verify(x => x.GetAllOrdersByCustomerId(id), Times.Never);
        }


    }
}
