using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : Controller
    {
        private readonly ISitterService _service;
        private readonly IMapper _mapper;

        public SittersController(ISitterService sitterService, IMapper mapper)
        {
            _service = sitterService;
            _mapper = mapper;
        }

        //api/sitters
        [HttpGet("{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [SwaggerOperation(Summary = "Get sitter by id")]
        [SwaggerResponse(200, "OK", typeof(SitterOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<SitterOutputModel> GetSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitter = _service.GetById(id);
            if (User.IsInRole("Admin"))
            {
                var sitterModel = _mapper.Map<SitterForAdminOutputModel>(sitter);
                return Ok(sitterModel);
            }
            else
            {
                var sitterModel = _mapper.Map<SitterOutputModel>(sitter);
                return Ok(sitterModel);
            }
        }

        [HttpGet]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [SwaggerOperation(Summary = "Get all sitters")]
        [SwaggerResponse(200, "OK", typeof(SitterOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<List<SitterOutputModel>> GetAllSitters()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitters = _service.GetAll();
            var sittersModel = _mapper.Map<List<SitterOutputModel>>(sitters);
            return Ok(sittersModel);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add sitter")]
        [SwaggerResponse(201, "Created", typeof(SitterOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult AddSitter([FromBody] SitterInsertInputModel sittetModel)
        {
            var sitter = _mapper.Map<SitterModel>(sittetModel);
            var id = _service.Add(sitter);
            return StatusCode(StatusCodes.Status201Created, id);
        }

        [HttpPut("{id}")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerOperation(Summary = "Update sitter")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateSitter([FromBody] SitterUpdateInputModel sitterModel)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitter = _mapper.Map<SitterModel>(sitterModel);
            _service.Update(userId.Value, sitter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        [SwaggerOperation(Summary = "Delete sitter")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteSitter(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.DeleteById(userId.Value, id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerOperation(Summary = "Restore sitter")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult RestoreSitter(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.Restore(id);
            return Ok();
        }

        [HttpPatch("confirm/{id}")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerOperation(Summary = "Confirm sitter's profile")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult ConfirmProfileSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.ConfirmProfileSitterById(id);
            return Ok();
        }

        [HttpPatch("block/{id}")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerOperation(Summary = "Block sitter's profile")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult BlockProfileSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.BlockProfileSitterById(id);
            return Ok();
        }

        [HttpGet("subwaystation/{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [SwaggerOperation(Summary = "Get all sitters by subway station Id")]
        [SwaggerResponse(200, "OK", typeof(SitterOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<List<SitterOutputModel>> GetAllSittersWithWorkTimeBySubwayStationId(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            if (User.IsInRole("Admin"))
            {
                var sittersForAdmin = _mapper.Map<List<SitterForAdminOutputModel>>(
                    _service.GetAllSittersWithWorkTimeBySubwayStationId(id));

                return Ok(sittersForAdmin);
            }
            else
            {
                var sitters = _mapper.Map<List<SitterOutputModel>>(
                    _service.GetAllSittersWithWorkTimeBySubwayStationId(id));

                return Ok(sitters);
            }
        }

        [HttpGet("with-services")]
        [SwaggerOperation(Summary = "Get all sitters with services")]
        [SwaggerResponse(200, "OK", typeof(SitterOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "Not Found", typeof(ExceptionResponse))]
        public ActionResult<List<SitterOutputModel>> GetAllSittersWithServices()
        {
            var sitters = _service.GetAllSittersWithServices();
            var sitterModels = _mapper.Map<List<SitterOutputModel>>(sitters);
            return Ok(sitterModels);
        }
    }
}
