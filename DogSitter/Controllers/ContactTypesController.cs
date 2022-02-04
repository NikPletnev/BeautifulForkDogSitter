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

        private ContactTypeService _service;
        private CustomMapper _map;

        public ContactTypesController()
        {
            _service = new ContactTypeService();
            _map = new CustomMapper();
        }

        //api/contact-types/42
        [HttpDelete("{id}")]
        public IActionResult DeleteContactType(int id)
        {
            _service.DeleteContactType(id);
            return NoContent();
        }

        //api/contact-types/42
        [HttpPatch("{id}")]
        public IActionResult RestoreContactType(int id)
        {
            _service.RestoreContactType(id);
            return NoContent();
        }

        //api/contact-types/42
        [HttpPut("{id}")]
        public IActionResult UpdateContactType(int id, [FromBody] ContactTypeInputModel сontactType)
        {
            _service.UpdateContactType(id, _map.GetInstance().Map<ContactTypeModel>(сontactType));
            return NoContent();
        }

        //api/contact-types
        [HttpPost]
        public ActionResult<ContactTypeOutputModel> AddContactType( [FromBody] ContactTypeInputModel сontactType)
        {
            _service.AddContactType(_map.GetInstance().Map<ContactTypeModel>(сontactType));
            return StatusCode(StatusCodes.Status201Created, _map.GetInstance().Map< ContactTypeOutputModel > (сontactType));
        }

        //api/contact-types/42
        [HttpGet("{id}")]
        public ActionResult<ContactTypeOutputModel> GetContactTypeById(int id)
        {
            //if сontactType exist
            var сontactType = _map.GetInstance().Map<ContactTypeOutputModel>(_service.GetContactTypeById(id));
            return Ok(сontactType);
            //if сontactType not found
            return NotFound($"ContactType {id} not found");
        }

        [HttpGet]
        public ActionResult<List<ContactTypeOutputModel>> GetAllContactTypes()
        {
            var сontactTypes = _map.GetInstance().Map<List<ContactTypeOutputModel>>(_service.GetAllContactTypes());
            return Ok(сontactTypes);
        }
    }
}
