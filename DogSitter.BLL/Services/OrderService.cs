using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
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
