using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.DAL.Repositories;

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
