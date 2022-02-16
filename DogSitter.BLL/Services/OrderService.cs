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
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OrderModel GetById(int id)
        {
            var order = _repository.GetById(id);

            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
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
            var order = _repository.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }
            _repository.Update(order);
        }

        public void DeleteById(OrderModel orderModel)
        {
            bool IsDelete = true;
            var order = _repository.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }
            _repository.Update(_mapper.Map<Order>(orderModel), IsDelete);
        }

        public void Restore(OrderModel orderModel)
        {
            bool IsDelete = false;
            var order = _repository.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }
            _repository.Update(_mapper.Map<Order>(orderModel), IsDelete);
        }

        public void EditOrderStatusByOrderId(int id, int status)
        {
            var order = _repository.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _repository.EditOrderStatusByOrderId(order, status);
        }
    }
}
