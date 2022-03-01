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
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpGet("sitters/subwaystation")]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStationsWhereSitterExist()
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService
                .GetAllSubwayStationsWhereSitterExist());

            return Ok(subwayStations);
        }

        //api/subwayStations
        [Authorize]
        [HttpGet]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStations()
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService.GetAllSubwayStations());

            return Ok(subwayStations);
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPost]
        public ActionResult AddSubwayStation([FromBody] SubwayStationInputModel subwayStation)
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
        [AuthorizeRole(Role.Admin)]
        [HttpPut("{id}")]
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
        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
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
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
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
