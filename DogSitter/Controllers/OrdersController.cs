﻿using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services.Interfaces;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpPut("{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [SwaggerOperation(Summary = "Update order")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
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

        [HttpPost]
        [AuthorizeRole(Role.Customer)]
        [SwaggerOperation(Summary = "Add order")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }
            var id = _service.Add(userId.Value, _mapper.Map<OrderModel>(order));
            return StatusCode(StatusCodes.Status201Created, id);
        }

        //api/orders/42
        [HttpPatch("{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [SwaggerOperation(Summary = "edit order")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
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
