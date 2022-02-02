using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactTypesController : Controller
    {

        private ContactTypeService _service = new ContactTypeService();

        [HttpDelete("{id}")]
        public IActionResult DeleteContactType(int id)
        {
            _service.DeleteContactType(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult RestoreContactType(int id)
        {
            _service.RestoreContactType(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContactType(int id, ContactTypeModel сontactType)
        {
            _service.UpdateContactType(id, сontactType);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<ContactTypeModel> AddContactType(ContactTypeModel сontactType)
        {
            _service.AddContactType(сontactType);
            return StatusCode(StatusCodes.Status201Created, сontactType);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactTypeModel> GetContactTypeById(int id)
        {
            //if сontactType exist
            var сontactType = _service.GetContactTypeById(id);
            return Ok(сontactType);
            //if сontactType not found
            return NotFound($"ContactType {id} not found");
        }

        [HttpGet]
        public ActionResult<List<ContactTypeModel>> GetAllContactTypes()
        {
            var сontactTypes = _service.GetAllContactTypes();
            return Ok(сontactTypes);
        }
    }
}
