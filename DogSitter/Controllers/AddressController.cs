using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IMapper mapper, IAddressService addressService)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<AddressOutputModel> GetAddressById(int id)
        {
            var address = _addressService.GetAddressById(id);
            return Ok(_mapper.Map<AddressOutputModel>(address));
        }

        [HttpGet]
        public ActionResult<List<AddressOutputModel>> GetAllAddresses()
        {
            var addresses = _addressService.GetAllAddresses();
            return Ok(_mapper.Map<AddressOutputModel>(addresses));
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody] AddressInputModel address)
        {
            _addressService.AddAddress(_mapper.Map<AddressModel>(address));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<AddressOutputModel>(address));
        }

        [HttpPut]
        public ActionResult UpdateAddress([FromBody] AddressInputModel address)
        {
            _addressService.UpdateAddress(_mapper.Map<AddressModel>(address));
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
