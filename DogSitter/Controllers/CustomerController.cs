﻿using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        private readonly CustomMapper _mapper; 

        public CustomerController()
        {
            _mapper = new CustomMapper();
            _service = new CustomerService();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerOutputModel> GetCustomerById(int id)
        {
            var customer = _service.GetCustomerById(id);
            return Ok(_mapper.GetInstance().Map<CustomerOutputModel>(customer));
        }

        [HttpGet]
        public ActionResult<List<CustomerOutputModel>> GetAllCustomers()
        {
            var customer = _service.GetAllCustomers();
            return Ok(_mapper.GetInstance().Map<CustomerOutputModel>(customer));
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] CustomerInputModel customer)
        {
            _service.AddCustomer(_mapper.GetInstance().Map<CustomerModel>(customer));
            return StatusCode(StatusCodes.Status201Created, _mapper.GetInstance().Map<CustomerOutputModel>(customer));
        }

        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] CustomerInputModel customer)
        {
            _service.UpdateCustomer(_mapper.GetInstance().Map<CustomerModel>(customer));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _service.DeleteCustomerById(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }

}
