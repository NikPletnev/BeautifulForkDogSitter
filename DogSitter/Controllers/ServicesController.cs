using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get service by id")]
        [SwaggerResponse(200, "OK", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<ServiceOutputModel> GetServiceById(int id)
        {
            var service = _mapper.Map<ServiceOutputModel>(_serviceService.GetServiceById(id));

            return service;
        }

        //api/Services
        [HttpGet]
        [SwaggerOperation(Summary = "Get all services")]
        [SwaggerResponse(200, "OK", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<List<ServiceOutputModel>> GetAllServices()
        {
            var services = _mapper.Map<List<ServiceOutputModel>>(_serviceService.GetAllServices());

            return services;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add service")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(201, "Created", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<ServiceOutputModel> AddService([FromBody] ServiceInsertInputModel service)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var serviceId = _serviceService.AddService(userId.Value, _mapper.Map<ServiceModel>(service));

            return StatusCode(StatusCodes.Status201Created, serviceId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update service")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateService(int id, [FromBody] ServiceUpdateInputModel service)
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
        [SwaggerOperation(Summary = "Delete service")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteService(int id)
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
        [SwaggerOperation(Summary = "Restore service")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult RestoreService(int id)
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
        [SwaggerOperation(Summary = "Get services by sitter id")]
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
