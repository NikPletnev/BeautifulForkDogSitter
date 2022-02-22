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
    public class DogsController : Controller
    {
        private IDogService _service;
        private IMapper _map;

        public DogsController(IMapper mapper, IDogService dogService)
        {
            _service = dogService;
            _map = mapper;
        }

        //api/dogs/42
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.DeleteDog(userId.Value, id);
            return NoContent();
        }

        //api/dogs/42
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public IActionResult RestoreDog(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.RestoreDog(id);
            return NoContent();
        }

        //api/dogs/42
        [AuthorizeRole(Role.Customer)]
        [HttpPut("{id}")]
        public IActionResult UpdateDog(int idDog, [FromBody] DogUpdateInputModel dog)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdateDog(userId.Value, idDog, _map.Map<DogModel>(dog));
            return NoContent();
        }

        //api/dogs
        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        public ActionResult<DogOutputModel> AddDog([FromBody] DogInsertInputModel dog)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.AddDog(userId.Value, _map.Map<DogModel>(dog));
            return StatusCode(StatusCodes.Status201Created, _map.Map<DogOutputModel>(dog));
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        public ActionResult<List<DogOutputModel>> GetAllDogs()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var dogs = _map.Map<List<DogOutputModel>>(_service.GetAllDogs());
            return Ok(dogs);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<List<DogOutputModel>> GetDogsByCustomerId(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var dogs = _map.Map<List<DogOutputModel>>(_service.GetDogsByCustomerId(id));
            return Ok(dogs);
        }
    }
}
