using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizeRole(Role.Admin)]
    public class AdminsController : Controller
    {
        private IAdminService _service;
        private IMapper _map;

        public AdminsController(IMapper CustomMapper, IAdminService adminService)
        {
            _service = adminService;
            _map = CustomMapper;
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
        [AuthorizeRole(Role.Sitter, Role.Admin, Role.Customer)]
        public ActionResult<List<AdminOutputModel>> GetAllAdmins()
        {
            var admins = _map.Map<List<AdminOutputModel>>(_service.GetAllAdmins());
            return Ok(admins);
        }
    }
}
