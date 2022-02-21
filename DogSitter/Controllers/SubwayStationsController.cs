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
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStation = _mapper.Map<SubwayStationOutputModel>(_subwayStationService
                .GetAllSubwayStationsWhereSitterExist());

            return Ok(subwayStation);
        }

        //api/subwayStations
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpGet]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStations()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService.GetAllSubwayStations());

            return Ok(subwayStations);
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPost]
        public IActionResult AddSubwayStation([FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.AddSubwayStation(_mapper.Map<SubwayStationModel>(subwayStation));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<SubwayStationOutputModel>(subwayStation));
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult UpdateSubwayStation(int id, [FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.UpdateSubwayStation(id, _mapper.Map<SubwayStationModel>(subwayStation));

            return NoContent();
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult DeleteSubwayStation(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.DeleteSubwayStation(id);

            return NoContent();
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public IActionResult RestoreSubwayStation(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _subwayStationService.RestoreSubwayStation(id);

            return NoContent();
        }
    }
}
