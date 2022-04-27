using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : Controller
    {
        private readonly IAdminService _service;
        private readonly IMapper _map;

        public AdminsController(IMapper CustomMapper, IAdminService adminService)
        {
            _service = adminService;
            _map = CustomMapper;
        }

        //api/admins/42
        [AuthorizeRole(Role.Admin)]
        [HttpPut]
        [SwaggerOperation(Summary = "Update admin")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
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
        [SwaggerOperation(Summary = "Get all admins")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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
