using DogSitter.API.Configs;
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

        private PassportService _service;
        private ICustomMapper _map;

        public PassportsController(ICustomMapper customMapper)
        {
            _service = new PassportService();
            _map = customMapper;
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePassport(int id, [FromBody] PassportUpdateInputModel passport)
        {
            _service.UpdatePassport(id, _map.GetInstance().Map<PassportModel>(passport));
            return NoContent();
        }

        [HttpPost]
        public ActionResult<PassportOutputModel> AddPassport([FromBody] PassportInsertInputModel passport)
        {
            _service.AddPassport(_map.GetInstance().Map<PassportModel>(passport));
            return StatusCode(StatusCodes.Status201Created, _map.GetInstance().Map<PassportOutputModel>(passport));
        }

        [HttpGet("{id}")]
        public ActionResult<PassportOutputModel> GetPassportById(int id)
        {
            //if passport exist
            var passport = _map.GetInstance().Map<PassportOutputModel>(_service.GetPassportById(id));
            return Ok(passport);
            //if passport not found
            return NotFound($"Passport {id} not found");
        }


    }
}
