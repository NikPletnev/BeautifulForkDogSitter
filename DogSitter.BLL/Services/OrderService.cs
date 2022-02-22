using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using DogSitter.BLL.Services.Interfaces;

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


        public void Update(OrderModel orderModel)
        {
            if (orderModel.Price == 0 ||
                orderModel.Status == 0 ||
                orderModel.Mark == null ||
                orderModel.Sitter == null)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the order {orderModel.Id}");
            }
            var order = _repository.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }

            _repository.Update(order, _mapper.Map<Order>(orderModel));
        }

        public void DeleteById(int id)
        {
            var order = _repository.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _repository.Update(order, true);
        }

        public void Restore(int id)
        {
            var order = _repository.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _repository.Update(order, false);
        }

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
