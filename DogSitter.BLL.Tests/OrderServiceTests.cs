using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Services;
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


        public void EditOrderStatusByOrderIdTest()
        {

        }

        [TestCase(1, 3)]
        public void EditOrderStatusByOrderIdTest_WhenOrderNotFound_ShouldThrowServiceNotFoundExeption(int id, int status)
        {
            //given
            _orderRepositoryMock.Setup(x => x.GetById(id));
            //when
            //then
            Assert.Throws<ServiceNotFoundExeption>(() => _service.EditOrderStatusByOrderId(id, status));
        }
    }
}
