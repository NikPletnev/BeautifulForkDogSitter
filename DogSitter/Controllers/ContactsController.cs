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
    public class ContactsController : Controller
    {
        private IContactService _service;
        private IMapper _map;

        public ContactsController(IMapper CustomMapper, IContactService contactService)
        {
            _service = contactService;
            _map = CustomMapper;
        }

        //api/contacts
        [AuthorizeRole(Role.Admin)]
        [HttpGet]
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
