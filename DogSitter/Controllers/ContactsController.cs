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
    public class ContactsController : Controller
    {
        private readonly IContactService _service;
        private readonly IMapper _map;

        public ContactsController(IMapper CustomMapper, IContactService contactService)
        {
            _service = contactService;
            _map = CustomMapper;
        }

        //api/contacts
        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all contacts")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        public ActionResult<List<ContactOutputModel>> GetAllContacts()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var сontacts = _map.Map<List<ContactOutputModel>>(_service.GetAllContacts());
            return Ok(сontacts);
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet("customer/{id}")]
        [SwaggerOperation(Summary = "Get all contacts by customerId")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        public ActionResult<List<ContactOutputModel>> GetAllContactsByCustomerId(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var сontacts = _map.Map<List<ContactOutputModel>>(_service.GetAllContactsByCustomerId(id));
            return Ok(сontacts);
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet("sitter/{id}")]
        [SwaggerOperation(Summary = "Get all contacts by sitterId")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        public ActionResult<List<ContactOutputModel>> GetAllContactsBySitterId(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var сontacts = _map.Map<List<ContactOutputModel>>(_service.GetAllContactsBySitterId(id));
            return Ok(сontacts);
        }


    }
}
