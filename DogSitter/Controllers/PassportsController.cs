using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassportsController : Controller
    {
        private IPassportService _service;
        private IMapper _map;

        public PassportsController(IMapper CustomMapper, IPassportService passportService)
        {
            _service = passportService;
            _map = CustomMapper;
        }

        [AuthorizeRole(Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult UpdatePassport(int id, [FromBody] PassportUpdateInputModel passport)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdatePassport(id, _map.Map<PassportModel>(passport));
            return NoContent();
        }
    }
}
