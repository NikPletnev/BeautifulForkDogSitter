using AutoMapper;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using DogSitter.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using DogSitter.API.Models;
using DogSitter.API.Attribute;
using DogSitter.DAL.Enums;
using System.Collections.Generic;

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

        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpPut("{id}")]
        public ActionResult UpdateOrder([FromRoute] int id, [FromBody] OrderUpdateInputModel order)
        {
            _service.Update(_mapper.Map<OrderModel>(order));
            return Ok();
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            _service.Add(_mapper.Map<OrderModel>(order));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<OrderOutputModel>(order));
        }

        //api/orders/42
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [HttpPatch("{id}")]
        public IActionResult EditOrderStatusByOrderId(int id, [FromBody] OrderStatusUpdateInputModel order)
        {
            _service.EditOrderStatusByOrderId(id, order.OrderNewStatus);

            return NoContent();
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpGet("{customer/id}")]
        public ActionResult GetAllOrdersByCustomerId(int id)
        {
            var orders = _mapper.Map<List<OrderOutputModel>>(_service.GetAllOrdersByCustomerId(id));
            return Ok(orders);
        }

        [AuthorizeRole(Role.Admin, Role.Sitter, Role.Customer)]
        [HttpGet("{sitter/id}")]
        public ActionResult GetAllOrdersBySitterId(int id)
        {
            var orders = _mapper.Map<List<OrderOutputModel>>(_service.GetAllOrdersBySitterId(id));
            return Ok(orders);
        }        
    }
}
