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
            return NoContent();
        }

        //api/admins/42
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, AdminModel admin)
        {
            _service.UpdateAdmin(id, admin);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<AdminModel> AddAdmin(AdminModel admin)
        {
            _service.AddAdmin(admin);
            return StatusCode(StatusCodes.Status201Created, admin);
        }

        //api/admins/42
        [HttpGet("{id}")]
        public ActionResult<AdminModel> GetAdminById(int id)
        {
            //if admin exist
            var admin = _service.GetAdminById(id);
            return Ok(admin);
            //if admin not found
            return NotFound($"Admin {id} not found");
        }

        //api/admins
        [HttpGet]
        public ActionResult<List<AdminModel>> GetAllAdmins()
        {
            var admins = _service.GetAllAdmins();
            return Ok(admins);
        }
    }
}
