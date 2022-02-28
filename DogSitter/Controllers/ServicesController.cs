using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        //api/Services/77
        [HttpGet("{id}")]
        [Description("Get service by id")]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public ActionResult<ServiceOutputModel> GetServiceById(int id)
        {
            var service = _mapper.Map<ServiceOutputModel>(_serviceService.GetServiceById(id));

            return service;
        }

        //api/Services
        [HttpGet]
        [Description("Get all services")]
        [ProducesResponseType(typeof(List<ServiceOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public ActionResult<List<ServiceOutputModel>> GetAllServices()
        {
            var services = _mapper.Map<List<ServiceOutputModel>>(_serviceService.GetAllServices());

            return services;
        }
        
        [HttpPost]
        [Description("Add service")]
        [AuthorizeRole(Role.Sitter)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<ServiceOutputModel> AddService([FromBody] ServiceInsertInputModel service)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.AddService(userId.Value, _mapper.Map<ServiceModel>(service));

            return _mapper.Map<ServiceOutputModel>(service);
        }
        
        [HttpPut("{id}")]
        [Description("Update service")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public IActionResult UpdateService(int id, [FromBody] ServiceUpdateInputModel service)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.UpdateService(userId.Value, id, _mapper.Map<ServiceModel>(service));

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Description("Delete service")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public IActionResult DeleteService(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.DeleteService(userId.Value, id);

            return NoContent();
        }
        
        [HttpPatch("{id}")]
        [Description("Restore service")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public IActionResult RestoreService(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.RestoreService(id);

            return NoContent();
        }

        //api/Services
        [HttpGet("by-sitter/{id}")]
        [Description("Get services by sitter id")]
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public ActionResult<List<ServiceOutputModel>> GetAllServicesBySitterId(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var services = _mapper.Map<List<ServiceOutputModel>>(
                _serviceService.GetAllServicesBySitterId(userId.Value, id));

            return services;
        }
    }
}
