using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassportsController : Controller
    {
        private IPassportService _service;
        private IMapper _map;

        public PassportsController(IMapper CustomMapperAPI, IPassportService passportService)
        {
            _service = passportService;
            _map = CustomMapperAPI;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePassport(int id, [FromBody] PassportUpdateInputModel passport)
        {
            _service.UpdatePassport(id, _map.Map<PassportModel>(passport));
            return NoContent();
        }

        [HttpPost]
        public ActionResult<PassportOutputModel> AddPassport([FromBody] PassportInsertInputModel passport)
        {
            _service.AddPassport(_map.Map<PassportModel>(passport));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public ActionResult<PassportOutputModel> GetPassportById(int id)
        {
            //if passport exist
            var passport = _map.Map<PassportOutputModel>(_service.GetPassportById(id));
            return Ok(passport);
        }
    }
}
