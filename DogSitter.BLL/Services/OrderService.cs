using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Helpers;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services.Interfaces;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace DogSitter.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _rep;
        private IMapper _map;
        private ISitterRepository _sitterRepository;
        private IUserRepository _userRepository;
        private ITimesheetRepository _timesheetRepository;
        private IBusyTimeRepository _busyTimeRepository;
        private IDogRepository _dogRepository;
        private IServiceRepository _serviceRepository;
        private ILogger<EmailSendller> _logger;
        private IAdminRepository _adminRepository;

        public OrderService(IOrderRepository orderRepository, ILogger<EmailSendller> logger, IAdminRepository adminRepository,
            ISitterRepository sitterRepository, IMapper mapper, IUserRepository userRepository, ITimesheetRepository timesheetRepository, IBusyTimeRepository busyTimeRepository, IDogRepository dogRepository, IServiceRepository serviceRepository)
        {
            _rep = orderRepository;
            _sitterRepository = sitterRepository;
            _adminRepository = adminRepository;
            _map = mapper;
            _userRepository = userRepository;
            _timesheetRepository = timesheetRepository;
            _busyTimeRepository = busyTimeRepository;
            _dogRepository = dogRepository;
            _serviceRepository = serviceRepository;
            _logger = logger;
        }

        public int Add(int userId, OrderModel orderModel)
        {
            orderModel.Price = GetOrderTotalSum(orderModel);
            var customer = (Customer)_userRepository.GetUserById(userId);
            var orderId = _rep.Add(_map.Map<Order>(orderModel), customer);

            EmailSendller emailSendller = new EmailSendller(_logger);
            //emailSendller.SendMessage(orderModel.Sitter, EmailMessage.NewOrderForSitter(orderId), EmailTopic.NewOrder);

            return orderId;
        }

        public void Update(int userId, OrderModel orderModel)
        {
            var user = _userRepository.GetUserById(userId);
            if (user.Role != Role.Customer)
            {
                throw new AccessException("Not enough rights");
            }

            var orderEntity = _rep.GetById(orderModel.Id);
            if (orderEntity == null)
            {
                throw new EntityNotFoundException($"Order {orderModel.Id} was not found");
            }

            //order.OrderDate = orderModel.OrderDate;
            orderEntity.Sitter = _sitterRepository.GetById(orderModel.Sitter.Id);
            orderEntity.Dog = _dogRepository.GetDogById(orderModel.Dog.Id);
            if (orderEntity.Service != null)
            {
                orderEntity.Service.Clear();
            }
            else
            {
                orderEntity.Service = new List<DAL.Entity.Serviсe>();
            }
            foreach (var item in orderModel.Services)
            {
                orderEntity.Service.Add(_serviceRepository.GetServiceById(item.Id));
            }
            if (orderModel.SitterBusyTime != null)
            {
                var listSitterGraffics = _map.Map<List<TimesheetModel>>(orderEntity.Sitter.Timesheets);
                var listSitterBusyTime = _map.Map<List<BusyTimeModel>>(orderEntity.Sitter.BusyTime);
                var orderModelBusyTime = orderModel.SitterBusyTime.TimeRange;
                foreach (var item in listSitterGraffics)
                {
                    if (orderModelBusyTime.CheckTimeCrossing(item.TimeRange))
                    {
                        throw new WorkTimeBusyException("This worktime is busy");
                    }
                }
                foreach (var item in listSitterBusyTime)
                {
                    if (orderModelBusyTime.CheckTimeCrossing(item.TimeRange)) { }
                    {
                        throw new WorkTimeBusyException("This worktime is busy");
                    }
                }
                orderEntity.SitterBusyTime = _map.Map<BusyTime>(orderModel.SitterBusyTime);
            }
            if (orderEntity.Status == Status.Created)
            {
                _rep.Update(orderEntity);
                EmailSendller emailSendller = new EmailSendller(_logger);
                emailSendller.SendMessage(orderModel.Sitter, EmailMessage.UpdateOrderForSitter(orderEntity.Id), EmailTopic.UpdateOrder);
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
            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_map.Map<SitterModel>(order.Sitter), EmailMessage.NewOrderStatus(order.Id, (Status)status), EmailTopic.UpdateOrder);
            emailSendller.SendMessage(_map.Map<CustomerModel>(order.Customer), EmailMessage.NewOrderStatus(order.Id, (Status)status), EmailTopic.UpdateOrder);
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
            var customer = _userRepository.GetUserById(userId);
            if (customer == null || customer.Role != Role.Customer)
            {
                throw new EntityNotFoundException($"Customer {id} was not found");
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

            EmailSendller emailSendller = new EmailSendller(_logger);
            emailSendller.SendMessage(_map.Map<SitterModel>(order.Sitter), EmailMessage.NewComment(order.Id), EmailTopic.UpdateOrder);

            var admins = _adminRepository.GetAllAdminWithContacts();
            var adminsModel = _map.Map<List<AdminModel>>(admins);

            foreach (var a in adminsModel)
            {
                emailSendller.SendMessage(a, EmailMessage.NewComment(order.Id), EmailTopic.NewCommentForAdmin);
            }

            var orders = _sitterRepository.GetAllSitterOrders(sitter);
            double SitterNewRating = 0;
            foreach (var item in orders)
            {
                SitterNewRating += item.Mark.Value;
            }
            if (orders.Count > 0)
            {
                SitterNewRating /= orders.Count;
            }
            if (sitter.Rating != SitterNewRating)
            {
                sitter.Rating = SitterNewRating;
                _sitterRepository.ChangeRating(sitter);
                emailSendller.SendMessage(_map.Map<SitterModel>(order.Sitter), EmailMessage.UpdateRatingSitter(sitter.Rating, SitterNewRating), EmailTopic.UpdateRating);
            }
        }

        private decimal GetOrderTotalSum(OrderModel orderModel)
        {
            if (orderModel.Services == null)
            {
                return 0;
            }
            return orderModel.Services.Select(s => s.Price).Sum();
        }

        public OrderModel GetOrderById(int id)
        {
            var order = _rep.GetById(id);
            if (order == null)
            {
                throw new EntityNotFoundException("Order not found");
            }
            return _map.Map<OrderModel>(order);
        }
    }
}
