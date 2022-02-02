using DogSitter.API.Configs;
using DogSitter.API.Models;
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

        //api/contactTypes/42
        [HttpDelete("{id}")]
        public IActionResult DeleteContactType(int id)
        {
            _service.DeleteContactType(id);
            return NoContent();
        }

        //api/contactTypes/42
        [HttpPatch("{id}")]
        public IActionResult RestoreContactType(int id)
        {
            _service.RestoreContactType(id);
            return NoContent();
        }

        //api/contactTypes/42
        [HttpPut("{id}")]
        public IActionResult UpdateContactType(int id, ContactTypeUpdateOutputModel сontactType)
        {
            _service.UpdateContactType(id, CustomMapper.GetInstance().Map<ContactTypeModel>(сontactType));
            return NoContent();
        }

        //api/contactTypes
        [HttpPost]
        public ActionResult<ContactTypeInsertInputModel> AddContactType(ContactTypeInsertInputModel сontactType)
        {
            _service.AddContactType(CustomMapper.GetInstance().Map<ContactTypeModel>(сontactType));
            return StatusCode(StatusCodes.Status201Created, сontactType);
        }

        //api/contactTypes/42
        [HttpGet("{id}")]
        public ActionResult<ContactTypeUpdateOutputModel> GetContactTypeById(int id)
        {
            //if сontactType exist
            var сontactType = CustomMapper.GetInstance().Map<ContactTypeUpdateOutputModel>(_service.GetContactTypeById(id));
            return Ok(сontactType);
            //if сontactType not found
            return NotFound($"ContactType {id} not found");
        }

        [HttpGet]
        public ActionResult<List<ContactTypeUpdateOutputModel>> GetAllContactTypes()
        {
            var сontactTypes = CustomMapper.GetInstance().Map<List<ContactTypeUpdateOutputModel>>(_service.GetAllContactTypes());
            return Ok(сontactTypes);
        }
    }
}
