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
            public IActionResult UpdatePassport(int id, PassportModel passport)
            {
                _service.UpdatePassport(id, passport);
                return NoContent();
            }

            [HttpPost]
            public ActionResult<PassportModel> AddPassport(PassportModel passport)
            {
                _service.AddPassport(passport);
                return StatusCode(StatusCodes.Status201Created, passport);
            }

            [HttpGet("{id}")]
            public ActionResult<PassportModel> GetPassportById(int id)
            {
                //if passport exist
                var passport = _service.GetPassportById(id);
                return Ok(passport);
                //if passport not found
                return NotFound($"Passport {id} not found");
            }

            
        }
}
