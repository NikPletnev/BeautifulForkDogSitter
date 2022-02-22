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
        private IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, 
            ISitterRepository sitterRepository, IMapper mapper, IUserRepository userRepository)
        {
            _rep = orderRepository;
            _customerRepository = customerRepository; 
            _sitterRepository = sitterRepository;
            _map = mapper;
            _userRepository = userRepository;
        }

        public void Add(int userId, OrderModel orderModel)
        {
            if (orderModel.OrderDate == DateTime.MinValue ||
                orderModel.Price == 0 ||
                orderModel.Status == 0 ||
                orderModel.Mark == null)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new order");
            }
            orderModel.Customer = _map.Map<CustomerModel>(_customerRepository.GetCustomerById(userId));
            _rep.Add(_map.Map<Order>(orderModel));
        }

        public void Update(int userId, OrderModel orderModel)
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
            var user = _userRepository.GetUserById(userId);
            if((user.Role == Role.Customer && orderModel.Customer.Id != userId))
            {
                throw new AccessException("Not enough rights");
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

        public void EditOrderStatusByOrderId(int userId, int id, int status)
        {
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {id} was not found");
            }
            var user = _userRepository.GetUserById(userId);
            if ((user.Role == Role.Customer && (Status)status != Status.CancelledByCustomer) ||
                (user.Role == Role.Sitter && (Status)status == Status.CanceledByAdmin))
            {
                throw new AccessException("Not enough rights");
            }
            _rep.EditOrderStatusByOrderId(order, status);
        }

        public List<OrderModel> GetAllOrdersBySitterId(int userId, int id)
        {
            var entity = _sitterRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }
            if(_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersBySitterId(id));
        }

        public List<OrderModel> GetAllOrdersByCustomerId(int userId, int id)
        {
            var entity = _customerRepository.GetCustomerById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }
            if (_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersByCustomerId(id));
        }


    }
}
