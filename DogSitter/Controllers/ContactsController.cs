using DogSitter.API.Configs;
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
        private readonly IContactService _service;
        private readonly CustomMapper _map;


        public ContactsController(IContactService contactService)
        {
            _service = contactService;
            _map = new CustomMapper();
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

        //api/contacts/42
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] ContactUpdateInputModel сontact)
        {
            _service.UpdateContact(id, _map.GetInstance().Map<ContactModel>(сontact));
            return NoContent();
        }

        //api/contacts
        [HttpPost]
        public ActionResult<ContactOutputModel> AddContact(ContactInsertInputModel сontact)
        {
            _service.AddContact(_map.GetInstance().Map<ContactModel>(сontact));
            return StatusCode(StatusCodes.Status201Created, _map.GetInstance().Map<ContactOutputModel>(сontact));
        }

        //api/contacts/42
        [HttpGet("{id}")]
        public ActionResult<ContactOutputModel> GetContactById(int id)
        {
            //if сontact exist
            var сontact = _map.GetInstance().Map<ContactOutputModel>(_service.GetContactById(id));
            return Ok(сontact);
            //if сontact not found
            return NotFound($"Contact {id} not found");
        }

        //api/contacts
        [HttpGet]
        public ActionResult<List<ContactOutputModel>> GetAllContacts()
        {
            var сontacts = _map.GetInstance().Map<List<ContactOutputModel>>(_service.GetAllContacts());
            return Ok(сontacts);
        }
    }
}
