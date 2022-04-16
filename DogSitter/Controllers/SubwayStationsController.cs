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
    public class SubwayStationsController : Controller
    {
        private readonly ISubwayStationService _subwayStationService;
        private readonly IMapper _mapper;

        public SubwayStationsController(ISubwayStationService subwayStationService, IMapper mapper)
        {
            _subwayStationService = subwayStationService;
            _mapper = mapper;
        }

        //api/subwayStations
        [HttpGet("where-sitters-exist")]
        [SwaggerOperation(Summary = "Get subway station where sitter exist")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [SwaggerResponse(200, "OK", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStationsWhereSitterExist()
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService
                .GetAllSubwayStationsWhereSitterExist());

            return subwayStations;
        }

        //api/subwayStations
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Get all subway stations")]
        [SwaggerResponse(200, "OK", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStations()
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService.GetAllSubwayStations());

            return subwayStations;
        }

        //api/subwayStation/77
        [HttpPost]
        [SwaggerOperation(Summary = "Add subway station")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(201, "Created", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<SubwayStationOutputModel> AddSubwayStation([FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStationId = _subwayStationService.AddSubwayStation(_mapper.Map<SubwayStationModel>(subwayStation));

            return StatusCode(StatusCodes.Status201Created, subwayStationId);
        }

        //api/subwayStation/77
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update subway station")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateSubwayStation(int id, [FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.UpdateSubwayStation(id, _mapper.Map<SubwayStationModel>(subwayStation));

            return NoContent();
        }

        //api/subwayStation/77
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete subway station")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteSubwayStation(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.DeleteSubwayStation(id);

            return NoContent();
        }

        //api/subwayStation/77
        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Restore subway station")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult RestoreSubwayStation(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.RestoreSubwayStation(id);

            return NoContent();
        }
    }
}
