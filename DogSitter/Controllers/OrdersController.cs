using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using DogSitter.API.Attribute;
using DogSitter.DAL.Enums;
using DogSitter.API.Extensions;
using DogSitter.BLL.Services.Interfaces;

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

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpPut("{id}")]
        public ActionResult UpdateOrder([FromRoute] int id, [FromBody] OrderUpdateInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.Update(userId.Value, _mapper.Map<OrderModel>(order));
            return Ok();
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var id = _service.Add(userId.Value, _mapper.Map<OrderModel>(order));
            var orderModel = _mapper.Map<OrderOutputModel>(order);
            orderModel.Id = id;
            return StatusCode(StatusCodes.Status201Created, orderModel);
        }

        //api/orders/42
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [HttpPatch("{id}")]
        public IActionResult EditOrderStatusByOrderId(int id, [FromBody] OrderStatusUpdateInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.EditOrderStatusByOrderId(userId.Value, id, order.OrderNewStatus);
            return NoContent();
        }

    }
}
