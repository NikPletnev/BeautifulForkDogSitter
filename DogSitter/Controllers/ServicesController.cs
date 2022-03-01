using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<ServiceOutputModel> GetServiceById(int id)
        {
            var service = _mapper.Map<ServiceOutputModel>(_serviceService.GetServiceById(id));

            return Ok(service);
        }

        //api/Services
        [HttpGet]
        public ActionResult<List<ServiceOutputModel>> GetAllServices()
        {
            var services = _mapper.Map<List<ServiceOutputModel>>(_serviceService.GetAllServices());

            return Ok(services);
        }

        [AuthorizeRole(Role.Sitter)]
        [HttpPost]
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

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpPut("{id}")]
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

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpDelete("{id}")]
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

        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
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
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [HttpGet("sitters/{id}")]
        public ActionResult<List<ServiceOutputModel>> GetAllServicesBySitterId(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var services = _mapper.Map<List<ServiceOutputModel>>(
                _serviceService.GetAllServicesBySitterId(userId.Value, id));

            return Ok(services);
        }

    }
}
