using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet]
        [AuthorizeRole(Role.Admin)]
        [SwaggerOperation(Summary = "Get all adresses")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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

        [HttpDelete("{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [SwaggerOperation(Summary = "Delete address")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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

        [HttpPatch]
        [AuthorizeRole(Role.Admin)]
        [SwaggerOperation(Summary = "Restore address")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
