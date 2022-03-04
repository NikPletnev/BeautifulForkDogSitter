using AutoMapper;
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

    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(IMapper CustomMapper, ICustomerService customerService)
        {
            _mapper = CustomMapper;
            _service = customerService;
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
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
            return Ok(_mapper.Map<List<CustomerOutputModel>>(customer));
        }

        [HttpPost]
        public ActionResult RegisterCustomer([FromBody] CustomerInputModel customer)
        {
            _service.AddCustomer(_mapper.Map<CustomerModel>(customer));
            return StatusCode(StatusCodes.Status201Created);
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] CustomerInputModel customer)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdateCustomer(userId.Value, _mapper.Map<CustomerModel>(customer));
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

            _service.DeleteCustomerById(userId.Value, id);
            return NoContent();
        }

        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public ActionResult RestoreCustomer(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.RestoreCustomer(id);
            return NoContent();
        }
    }

}
