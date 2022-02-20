using AutoMapper;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _service;
        private IMapper _map;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _service = orderService;
            _map = mapper;
        }

        //api/orders/42
        [Authorize]
        [HttpPatch("{id}")]
        public IActionResult EditOrderStatusByOrderId(int id, [FromBody] OrderStatusUpdateInputModel order)
        {
            _service.EditOrderStatusByOrderId(id, order.OrderNewStatus);

            return NoContent();
        }
    }
}
