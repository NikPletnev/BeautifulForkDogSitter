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

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpPost]
        public ActionResult<ServiceOutputModel> AddService([FromBody] ServiceInsertInputModel service)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.AddService(_mapper.Map<ServiceModel>(service));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<ServiceOutputModel>(service));
        }

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpPut]
        public IActionResult UpdateService([FromBody] ServiceUpdateInputModel service)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _serviceService.UpdateService(_mapper.Map<ServiceModel>(service));
            return NoContent();
        }

        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [HttpDelete]
        public IActionResult DeleteService([FromBody] ServiceUpdateInputModel service)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }
            _serviceService.DeleteService(_mapper.Map<ServiceModel>(service));
            return NoContent();
        }
    }
}
