using AutoMapper;
using DogService.BLL.Services;
using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
            _mapper = new CustomMapper().GetInstance();
        }

        //api/Services/77
        [HttpGet("{id}")]
        public ActionResult<ServiceOutputModel> GetServiceById(int id)
        {
            var service = _mapper.Map<ServiceOutputModel>(_serviceService.GetServiceById(id));
            return Ok(service);

            return NotFound($"Service {id} not found");
        }

        //api/Services
        [HttpGet]
        public ActionResult<List<ServiceOutputModel>> GetAllServices()
        {
            var services = _mapper.Map<List<ServiceOutputModel>>(_serviceService.GetAllServices());

            return Ok(services);
        }

        [HttpPost]
        public ActionResult<ServiceOutputModel> AddService([FromBody] ServiceInsertInputModel service)
        {
            _serviceService.AddService(_mapper.Map<ServiceModel>(service));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<ServiceOutputModel>(service));
        }

        //api/Services/77
        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, [FromBody] ServiceUpdateInputModel service)
        {
            _serviceService.UpdateService(id, _mapper.Map<ServiceModel>(service));

            return NoContent();
        }

        //api/Services/77
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            _serviceService.DeleteService(id);

            return NoContent();
        }

        //api/Services/77
        [HttpPatch("{id}")]
        public IActionResult RestoreService(int id)
        {
            _serviceService.RestoreService(id);

            return Ok();
        }
    }
}
