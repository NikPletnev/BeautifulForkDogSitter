using DogSitter.API.Models;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<AddressOutputModel> GetAddressById(int id)
        {

            return Ok();
        }

        [HttpGet]
        public ActionResult<List<AddressOutputModel>> GetAllAddresses()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] AddressInputModel address)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult UpdateAddress([FromBody] AddressInputModel address)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
