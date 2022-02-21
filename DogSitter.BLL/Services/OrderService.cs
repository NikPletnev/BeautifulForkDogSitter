using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services.Interface;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

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
            _repository.Update(order);
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
            _repository.Update(_mapper.Map<Order>(order), false);
        }
        public OrderModel GetById(int id)
        {
            var order = _rep.GetById(id);

            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }

            return _map.Map<OrderModel>(order);
        }

        public List<OrderModel> GetAll() =>
             _map.Map<List<OrderModel>>(_rep.GetAll());

        public void Add(OrderModel orderModel)
        {
            if (orderModel.OrderDate == DateTime.MinValue ||
                orderModel.Price == 0 ||
                orderModel.Status == 0 ||
                orderModel.Mark == null)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new order");
            }

            _rep.Add(_map.Map<Order>(orderModel));
        }

        public void Update(OrderModel orderModel)
        {
            if (orderModel.Price == 0 ||
                orderModel.Status == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the order {orderModel.Id}");
            }
            var order = _rep.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }
            if (order.Status == Status.Created)
            {
                _rep.Update(order, _map.Map<Order>(orderModel));
            }
            else
            {
                throw new Exception($"Order { orderModel.Id } has been accepted, it cannot be edited");
            }
        }

        public void DeleteById(int id)
        {
            bool IsDelete = true;
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _rep.Update(order, IsDelete);
        }

        public void Restore(int id)
        {
            bool IsDelete = false;
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _rep.Update(order, IsDelete);
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

        public List<OrderModel> GetAllOrdersBySitterId(int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersBySitterId(id));
        }

        public List<OrderModel> GetAllOrdersByCustomerId(int id)
        {
            var entity = _customerRepository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersByCustomerId(id));
        }


    }
}
