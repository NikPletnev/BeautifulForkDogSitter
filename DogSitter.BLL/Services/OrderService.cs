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
        private readonly IOrderRepository _rep;
        private IMapper _map;
        private ISitterRepository _sitterRepository;
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;
        private IWorkTimeRepository _workTimeRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository,
            ISitterRepository sitterRepository, IMapper mapper, IUserRepository userRepository, IWorkTimeRepository workTimeRepository)
        {
            _rep = orderRepository;
            _customerRepository = customerRepository;
            _sitterRepository = sitterRepository;
            _map = mapper;
            _userRepository = userRepository;
            _workTimeRepository = workTimeRepository;
        }

        public void Add(int userId, OrderModel orderModel)
        {
            if (orderModel.OrderDate == DateTime.MinValue ||
                orderModel.Status == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new order");
            }

            orderModel.Price = GetOrderTotalSum(orderModel);
            var customer = (Customer)_userRepository.GetUserById(userId);
            _rep.Add(_map.Map<Order>(orderModel), customer);
        }

        public void Update(int userId, OrderModel orderModel)
        {
            var order = _rep.GetById(orderModel.Id);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }

            if(order.Sitter != null)
            {
            var orderOldWorkTime = _workTimeRepository.GetWorkTimeById(order.SitterWorkTime.Id);
            _workTimeRepository.ChangeWorkTimeStatus(orderOldWorkTime, false);
            }

            var workTime = _workTimeRepository.GetWorkTimeById(orderModel.SitterWorkTime.Id);

            if (workTime == null)
            {
                throw new WorkTimeBusyException("This worktime is busy");
            }

            _workTimeRepository.ChangeWorkTimeStatus(workTime, true);

            var user = _userRepository.GetUserById(userId);
            if ((user.Role == Role.Customer && orderModel.Customer.Id != userId))
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
            var sitter = _userRepository.GetUserById(id);
            if (sitter == null || sitter.Role != Role.Sitter)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }
            if (_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersBySitterId(id));
        }

        public List<OrderModel> GetAllOrdersByCustomerId(int userId, int id)
        {
            var customer = _userRepository.GetUserById(id);
            if (customer == null || customer.Role != Role.Customer)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
            }
            
            if (_userRepository.GetUserById(userId).Role != Role.Admin && userId != id)
            {
                throw new AccessException("Not enough rights");
            }
            return _map.Map<List<OrderModel>>(_rep.GetAllOrdersByCustomerId(id));
        }

        public void AddCommentAndMarkAboutOrder(int id, OrderModel order)
        {
            var entity = _rep.GetById(id);
            var sitter = _sitterRepository.GetById(entity.Sitter.Id);
            
            if (entity == null)
            {
                throw new EntityNotFoundException($"Order was not found");
            }
            _rep.LeaveCommentAndRateOrder(entity, _map.Map<Order>(order));
            var orders = _sitterRepository.GetAllSitterOrders(sitter);
            int SitterNewRating = 0;
            foreach (var item in orders)
            {
                SitterNewRating += item.Mark.Value;
            }
            SitterNewRating /= orders.Count;
            sitter.Rating = SitterNewRating;
            _sitterRepository.ChangeRating(sitter);
        }

        private decimal GetOrderTotalSum(OrderModel orderModel)
        {
            if(orderModel.Services == null)
            {
                return 0;
            }
            return orderModel.Services.Select(s => s.Price).Sum();
        }

        public OrderModel GetOrderById(int id)
        {
            var order = _rep.GetById(id);
            if(order == null)
            {
                throw new EntityNotFoundException("Order not found");
            }
            return _map.Map<OrderModel>(order);
        }
    }
}
