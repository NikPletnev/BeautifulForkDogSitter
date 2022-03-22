using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get customer by id")]
        [SwaggerResponse(201, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Get all customer")]
        [SwaggerResponse(201, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Add customer")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult RegisterCustomer([FromBody] CustomerInputModel customer)
        {
            var id = _service.AddCustomer(_mapper.Map<CustomerModel>(customer));
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPut]
        [SwaggerOperation(Summary = "Update customer")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateCustomer([FromBody] CustomerUpdateInputModel customer)
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
        [SwaggerOperation(Summary = "Delete customer")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Restore customer")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
