using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Entity;
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
        private readonly IOrderRepository _repository;
        private IMapper _mapper;
        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public OrderModel GetById(int id)
        {
            var order = _repository.GetById(id);

            if (order == null)
            {
                throw new ServiceNotFoundExeption($"Order {id} was not found");
        }

            return _mapper.Map<OrderModel>(order);
        }

        public List<OrderModel> GetAll() =>
             _mapper.Map<List<OrderModel>>(_repository.GetAll());

        public void Add(OrderModel orderModel)
        {
            if (orderModel.OrderDate == DateTime.MinValue ||
                orderModel.Price == 0 ||
                orderModel.Status == 0 ||
                orderModel.Mark == null)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new order");
            }

            _repository.Add(_mapper.Map<Order>(orderModel));
        }

        public void Update(OrderModel orderModel)
        {
            if (orderModel.Price == 0 ||
                orderModel.Status == 0 ||
                orderModel.Mark == null)
        {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the order {orderModel.Id}");
            }
            var entity = _mapper.Map<Order>(orderModel);
            var order = _repository.GetById(orderModel.Id);
            if (order == null)
            {
                throw new ServiceNotFoundExeption($"Order {orderModel.Id} was not found");
            }
            _repository.Update(order);
        }

        public void DeleteById(int id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
            {
                throw new ServiceNotFoundExeption($"Order {id} was not found");
            }

            bool IsDelete = true;
            _repository.Update(id, IsDelete);
        }

        public void Restore(int id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
            {
                throw new ServiceNotFoundExeption($"Order {id} was not found");
            }

            bool IsDelete = false;
            _repository.Update(id, IsDelete);
        }
    }
}
