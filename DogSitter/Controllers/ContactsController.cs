using Microsoft.AspNetCore.Mvc;
using DogSitter.BLL.Services;
using DogSitter.BLL.Models;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private ContactService _service = new ContactService();

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _service.DeleteContact(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult RestoreContact(int id)
        {
            _service.RestoreContact(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactModel сontact)
        {
            _service.UpdateContact(id, сontact);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<ContactModel> AddContact(ContactModel сontact)
        {
            _service.AddContact(сontact);
            return StatusCode(StatusCodes.Status201Created, сontact);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactModel> GetContactById(int id)
        {
            //if сontact exist
            var сontact = _service.GetContactById(id);
            return Ok(сontact);
            //if сontact not found
            return NotFound($"Contact {id} not found");
        }

        [HttpGet]
        public ActionResult<List<ContactModel>> GetAllContacts()
        {
            var сontacts = _service.GetAllContacts();
            return Ok(сontacts);
        }
    }
}
