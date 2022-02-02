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
       
            private PassportService _service = new PassportService();

            [HttpPut("{id}")]
            public IActionResult UpdatePassport(int id, PassportUpdateOutputModel passport)
            {
                _service.UpdatePassport(id, CustomMapper.GetInstance().Map<PassportModel>(passport));
                return NoContent();
            }

            [HttpPost]
            public ActionResult<PassportInsertInputModel> AddPassport(PassportInsertInputModel passport)
            {
                _service.AddPassport(CustomMapper.GetInstance().Map < PassportModel > (passport));
                return StatusCode(StatusCodes.Status201Created, passport);
            }

            [HttpGet("{id}")]
            public ActionResult<PassportUpdateOutputModel> GetPassportById(int id)
            {
                //if passport exist
                var passport = CustomMapper.GetInstance().Map<PassportUpdateOutputModel>(_service.GetPassportById(id));
                return Ok(passport);
                //if passport not found
                return NotFound($"Passport {id} not found");
            }

            
        }
}
