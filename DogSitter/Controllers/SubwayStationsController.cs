using AutoMapper;
using DogSitter.API.Attribute;
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
            var subwayStation = _mapper.Map<SubwayStationOutputModel>(_subwayStationService
                .GetAllSubwayStationsWhereSitterExist());

            return Ok(subwayStation);
        }

        //api/subwayStations
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpGet]
        public ActionResult<List<SubwayStationOutputModel>> GetAllSubwayStations()
        {
            var subwayStations = _mapper.Map<List<SubwayStationOutputModel>>(_subwayStationService.GetAllSubwayStations());

            return Ok(subwayStations);
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPost]
        public IActionResult AddSubwayStation([FromBody] SubwayStationInputModel subwayStation)
        {
            _subwayStationService.AddSubwayStation(_mapper.Map<SubwayStationModel>(subwayStation));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<SubwayStationOutputModel>(subwayStation));
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult UpdateSubwayStation(int id, [FromBody] SubwayStationInputModel subwayStation)
        {
            _subwayStationService.UpdateSubwayStation(id, _mapper.Map<SubwayStationModel>(subwayStation));

            return NoContent();
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult DeleteSubwayStation(int id)
        {
            _subwayStationService.DeleteSubwayStation(id);

            return NoContent();
        }

        //api/subwayStation/77
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public IActionResult RestoreSubwayStation(int id)
        {
            _subwayStationService.RestoreSubwayStation(id);

            return NoContent();
        }
    }
}
