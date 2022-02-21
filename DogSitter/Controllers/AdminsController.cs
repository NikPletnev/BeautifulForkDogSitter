using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
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
        [AuthorizeRole(Role.Admin)]
        [HttpPut]
        public IActionResult UpdateAdmin([FromBody] AdminUpdateInputModel admin)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdateAdmin(userId.Value, _map.Map<AdminModel>(admin));
            return NoContent();
        }

        //api/admins
        [HttpGet]
        [Authorize]
        public ActionResult<List<AdminOutputModel>> GetAllAdmins()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var admins = _map.Map<List<AdminOutputModel>>(_service.GetAllAdminsWithContacts());
            return Ok(admins);
        }
    }
}
