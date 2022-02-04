using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Address> GetAddressById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Address>> GetAllAddresses()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] Address address)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult UpdateAddress([FromBody] Address address)
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
