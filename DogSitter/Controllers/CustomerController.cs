﻿using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(IMapper CustomMapper, ICustomerService customerService)
        {
            _mapper = CustomMapper;
            _service = customerService;
        }

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpGet("{id}")]
        public ActionResult<CustomerOutputModel> GetCustomerById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var customer = _service.GetCustomerById(id);

            return Ok(_mapper.Map<CustomerOutputModel>(customer));
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        public ActionResult<List<CustomerOutputModel>> GetAllCustomers()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var customer = _service.GetAllCustomers();
            return Ok(_mapper.Map<CustomerOutputModel>(customer));
        }

        [HttpPost]
        public ActionResult RegisterCustomer([FromBody] CustomerInputModel customer)
        {
            _service.AddCustomer(_mapper.Map<CustomerModel>(customer));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<CustomerOutputModel>(customer));
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] CustomerInputModel customer)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdateCustomer(id, _mapper.Map<CustomerModel>(customer));
            return Ok();
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.DeleteCustomerById(id);
            return NoContent();
        }
    }

}
