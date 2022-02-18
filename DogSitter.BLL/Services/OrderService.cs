using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _rep;
        private IMapper _map;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _rep = orderRepository;
            _map = mapper;
        }

        public void UpdateOrder(int id, OrderModel order)
        {
            var entity = _rep.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            if (entity.Status == Status.Created)
            {
                _rep.Update(entity, _map.Map<Order>(order));
            }
            else
            {
                throw new Exception($"Order {id} has been accepted, it cannot be edited");
            }
        }

        public void EditOrderStatusByOrderId(int id, int status)
        {
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _rep.EditOrderStatusByOrderId(order, status);
        }
    }
}
