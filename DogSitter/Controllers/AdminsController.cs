using AutoMapper;
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
        private IAdminService _service;
        private IMapper _map;

        public AdminsController(IMapper customMapper, IAdminService adminService)
        {
            _service = adminService;
            _map = customMapper;
        }

        //api/admins/42
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] AdminUpdateInputModel admin)
        {
            _service.UpdateAdmin(id, _map.Map<AdminModel>(admin));
            return NoContent();
        }

        //api/admins
        [HttpGet]
        public ActionResult<List<AdminOutputModel>> GetAllAdmins()
        {
            var admins = _map.Map<List<AdminOutputModel>>(_service.GetAllAdmins());
            return Ok(admins);
        }
    }
}
