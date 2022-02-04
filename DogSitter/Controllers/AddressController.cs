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
        private readonly CustomMapper _mapper;

        public AddressController()
        {
            _addressService = new AddressService();
            _mapper = new CustomMapper();
        }

        [HttpGet("{id}")]
        public ActionResult<AddressOutputModel> GetAddressById(int id)
        {
            var address = _addressService.GetAddressById(id);
            return Ok(_mapper.GetInstance().Map<AddressOutputModel>(address));
        }

        [HttpGet]
        public ActionResult<List<AddressOutputModel>> GetAllAddresses()
        {
            var addresses = _addressService.GetAllAddresses();
            return Ok(_mapper.GetInstance().Map<AddressOutputModel>(addresses));
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] AddressInputModel address)
        {
            _addressService.AddAddress(_mapper.GetInstance().Map<AddressModel>(address));
            return StatusCode(StatusCodes.Status201Created, _mapper.GetInstance().Map<AddressOutputModel>(address));
        }

        [HttpPut]
        public ActionResult UpdateAddress([FromBody] AddressInputModel address)
        {
            _addressService.UpdateAddress(_mapper.GetInstance().Map<AddressModel>(address));
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
