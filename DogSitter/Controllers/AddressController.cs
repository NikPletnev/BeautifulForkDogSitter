using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
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

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        public ActionResult<List<AddressOutputModel>> GetAllAddresses()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var addresses = _addressService.GetAllAddresses();
            return Ok(_mapper.Map<List<AddressOutputModel>>(addresses));
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _addressService.DeleteAddressById(userId.Value, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [AuthorizeRole(Role.Admin)]
        [HttpPatch]
        public ActionResult RestoreAddress(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _addressService.RestoreAddress(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
