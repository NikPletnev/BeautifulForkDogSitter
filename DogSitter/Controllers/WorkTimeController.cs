using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTimeController : Controller
    {
        private readonly IWorkTimeService _workTimeService;
        private readonly IMapper _mapper;

        public WorkTimeController(IWorkTimeService workTimeService, IMapper mapper)
        {
            _workTimeService = workTimeService;
            _mapper = mapper;
        }

        //api/workTimes/77
        [HttpGet("{id}")]
        public ActionResult<WorkTimeOutputModel> GetWorkTimeById(int id)
        {
            var workTime = _mapper.Map<WorkTimeOutputModel>(_workTimeService.GetWorkTimeById(id));
            if (workTime != null)
                return Ok(workTime);
            else
                return NotFound($"WorkTime {id} not found");
        }

        //api/workTimes
        [HttpGet]
        public ActionResult<List<WorkTimeOutputModel>> GetAllWorkTimes()
        {
            var workTimes = _mapper.Map<List<WorkTimeOutputModel>>(_workTimeService.GetAllWorkTimes());

            return Ok(workTimes);
        }

        [HttpPost]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            _workTimeService.AddWorkTime(_mapper.Map<WorkTimeModel>(workTime));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<WorkTimeOutputModel>(workTime));
        }

        //api/workTimes/77
        [HttpPut("{id}")]
        public IActionResult UpdateWorkTime(int id, [FromBody] WorkTimeUpdateInputModel workTime)
        {
            _workTimeService.UpdateWorkTime(id, _mapper.Map<WorkTimeModel>(workTime));

            return NoContent();
        }
         
        //api/workTimes/77
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkTime(int id)
        {
            _workTimeService.DeleteWorkTime(id);

            return NoContent();
        }

        //api/workTimes/77
        [HttpPatch("{id}")]
        public IActionResult RestoreWorkTime(int id)
        {
            _workTimeService.RestoreWorkTime(id);

            return Ok();
        }
    }
}
