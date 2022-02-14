using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
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

        //api/contacts/42
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _service.DeleteContact(id);
            return NoContent();
        }

        //api/contacts/42
        [HttpPatch("{id}")]
        public IActionResult RestoreContact(int id)
        {
            _service.RestoreContact(id);
            return NoContent();
        }

        //api/contacts
        [HttpPost]
        public ActionResult<ContactOutputModel> AddContact(ContactInsertInputModel сontact)
        {
            _service.AddContact(_map.Map<ContactModel>(сontact));
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/contacts/42
        [HttpGet("{id}")]
        public ActionResult<ContactOutputModel> GetContactById(int id)
        {
            var сontact = _map.Map<ContactOutputModel>(_service.GetContactById(id));
            return Ok(сontact);
        }

        //api/contacts
        [HttpGet]
        public ActionResult<List<ContactOutputModel>> GetAllContacts()
        {
            var сontacts = _map.Map<List<ContactOutputModel>>(_service.GetAllContacts());
            return Ok(сontacts);
        }
    }
}
