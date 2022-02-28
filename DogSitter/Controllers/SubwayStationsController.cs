using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubwayStationsController : Controller
    {
        private ISubwayStationService _subwayStationService;
        private IMapper _mapper;

        public SubwayStationsController(ISubwayStationService subwayStationService, IMapper mapper)
        {
            _subwayStationService = subwayStationService;
            _mapper = mapper;
        }

        //api/subwayStations
        [HttpGet("by-sitters")]
        [Description("Get subway station where sitter exist")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
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
        [Description("Get all subway stations")]
        [ProducesResponseType(typeof(List<ServiceOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
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
        [Description("Add subway station")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<SubwayStationOutputModel> AddSubwayStation([FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.AddSubwayStation(_mapper.Map<SubwayStationModel>(subwayStation));

            return _mapper.Map<SubwayStationOutputModel>(subwayStation);
        }

        //api/subwayStation/77
        [HttpPut("{id}")]
        [Description("Update subway station")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public IActionResult UpdateSubwayStation(int id, [FromBody] SubwayStationInputModel subwayStation)
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
        [Description("Delete subway station")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public IActionResult DeleteSubwayStation(int id)
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
        [Description("Restore subway station")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public IActionResult RestoreSubwayStation(int id)
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
