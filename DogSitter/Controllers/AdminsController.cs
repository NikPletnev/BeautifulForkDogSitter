using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : Controller
    {
        private AdminService _service = new AdminService();

        //api/admins/42
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            _service.DeleteAdmin(id);
            return NoContent();
        }

        //api/admins/42
        [HttpPatch("{id}")]
        public IActionResult RestoreAdmin(int id)
        {
            _service.RestoreAdmin(id);
            return Ok();
        }

        //api/admins/42
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminUpdateOutputModel admin)
        {
            _service.UpdateAdmin(id, CustomMapper.GetInstance().Map<AdminModel>(admin));
            return NoContent();
        }

        [HttpPost]
        public ActionResult<AdminInsertInputModel> AddAdmin([FromBody] AdminInsertInputModel admin)
        {
            _service.AddAdmin(CustomMapper.GetInstance().Map<AdminModel>(admin));
            return StatusCode(StatusCodes.Status201Created, admin);
        }

        //api/admins/42
        [HttpGet("{id}")]
        public ActionResult<AdminOutputModel> GetAdminById(int id)
        {
            var admin = CustomMapper.GetInstance().Map<AdminOutputModel>(_service.GetAdminById(id));
            //if admin exist
            return Ok(admin);
            //if admin not found
            return NotFound($"Admin {id} not found");
        }

        //api/admins
        [HttpGet]
        public ActionResult<List<AdminOutputModel>> GetAllAdmins()
        {
            var admins = CustomMapper.GetInstance().Map<List<AdminOutputModel>>
                                                                (_service.GetAllAdmins());
            return Ok(admins);
        }
    }
}
