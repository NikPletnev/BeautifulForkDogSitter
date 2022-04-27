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
    public class DogsController : Controller
    {
        private readonly IDogService _service;
        private readonly IMapper _map;

        public DogsController(IMapper mapper, IDogService dogService)
        {
            _service = dogService;
            _map = mapper;
        }

        //api/dogs/42
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete dog")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Restore dog")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Update dog")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public IActionResult UpdateDog(int id, [FromBody] DogUpdateInputModel dog)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.UpdateDog(userId.Value, id, _map.Map<DogModel>(dog));
            return NoContent();
        }

        //api/dogs
        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        [SwaggerOperation(Summary = "Add dog")]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<DogOutputModel> AddDog([FromBody] DogInsertInputModel dog)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            int id = _service.AddDog(userId.Value, _map.Map<DogModel>(dog));
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all dog")]
        [SwaggerResponse(201, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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
        [SwaggerOperation(Summary = "Get dogs by customerId")]
        [SwaggerResponse(201, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
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
