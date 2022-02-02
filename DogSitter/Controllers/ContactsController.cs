using Microsoft.AspNetCore.Mvc;
using DogSitter.BLL.Services;
using DogSitter.BLL.Models;
using DogSitter.API.Models;
using DogSitter.API.Configs;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private ContactService _service = new ContactService();
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
        public IActionResult UpdateContact(int id, [FromBody] ContactUpdateOutputModel сontact)
        {
            _service.UpdateContact(id, CustomMapper.GetInstance().Map<ContactModel> (сontact));
            return NoContent();
        }

        //api/contacts
        [HttpPost]
        public ActionResult<ContactInsertInputModel> AddContact(ContactInsertInputModel сontact)
        {
            _service.AddContact(CustomMapper.GetInstance().Map<ContactModel>(сontact));
            return StatusCode(StatusCodes.Status201Created, сontact);
        }

        //api/contacts/42
        [HttpGet("{id}")]
        public ActionResult<ContactUpdateOutputModel> GetContactById(int id)
        {
            //if сontact exist
            var сontact = CustomMapper.GetInstance().Map<ContactUpdateOutputModel>(_service.GetContactById(id));
            return Ok(сontact);
            //if сontact not found
            return NotFound($"Contact {id} not found");
        }

        //api/contacts
        [HttpGet]
        public ActionResult<List<ContactUpdateOutputModel>> GetAllContacts()
        {
            var сontacts = CustomMapper.GetInstance().Map<List<ContactUpdateOutputModel>>(_service.GetAllContacts());
            return Ok(сontacts);
        }
    }
}
