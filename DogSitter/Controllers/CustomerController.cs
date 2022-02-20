﻿using AutoMapper;
using DogSitter.API.Attribute;
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
            var customer = _service.GetCustomerById(id);

            return Ok(_mapper.Map<CustomerOutputModel>(customer));
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        public ActionResult<List<CustomerOutputModel>> GetAllCustomers()
        {
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
        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] CustomerInputModel customer)
        {
            _service.UpdateCustomer(_mapper.Map<CustomerModel>(customer));

            return Ok();
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _service.DeleteCustomerById(id);

            return NoContent();
        }
    }

}
