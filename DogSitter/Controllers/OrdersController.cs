using AutoMapper;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using DogSitter.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using DogSitter.API.Models;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _service;
        private IMapper _mapper;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _service = orderService;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder([FromRoute] int id, [FromBody] OrderUpdateInputModel order)
        {
            _service.Update(_mapper.Map<OrderModel>(order));
            return Ok();
        }

        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            _service.Add(_mapper.Map<OrderModel>(order));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<OrderOutputModel>(order));
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
