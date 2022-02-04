using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController()
        {
            _addressService = new AddressService();
        }

        [HttpGet("{id}")]
        public ActionResult<AddressOutputModel> GetAddressById(int id)
        {
            var address = _addressService.GetAddressById(id);
            return Ok(CustomMapper.GetInstance().Map<AddressModel>(address));
        }

        [HttpGet]
        public ActionResult<List<AddressOutputModel>> GetAllAddresses()
        {
            var addresses = _addressService.GetAllAddresses();
            return Ok(CustomMapper.GetInstance().Map<AddressModel>(addresses));
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] AddressInputModel address)
        {
            _addressService.AddAddress(CustomMapper.GetInstance().Map<AddressModel>(address));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult UpdateAddress([FromBody] AddressInputModel address)
        {
            _addressService.UpdateAddress(CustomMapper.GetInstance().Map<AddressModel>(address));
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            _addressService.DeleteAddressById(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
