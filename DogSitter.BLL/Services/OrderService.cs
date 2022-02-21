using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services.Interface;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _rep;
        private IMapper _map;
        private ISitterRepository _sitterRepository;
        private ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, ISitterRepository sitterRepository, IMapper mapper)
        {
            _rep = orderRepository;
            _customerRepository = customerRepository; 
            _sitterRepository = sitterRepository;
            _map = mapper;
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
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            _rep.EditOrderStatusByOrderId(order, status);
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
