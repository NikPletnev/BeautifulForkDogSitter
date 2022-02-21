using AutoMapper;
using DogSitter.API.Extensions;
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

        [HttpPost]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.AddWorkTime(_mapper.Map<WorkTimeModel>(workTime));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<WorkTimeOutputModel>(workTime));
        }

        //api/workTimes/77
        [HttpPut("{id}")]
        public IActionResult UpdateWorkTime( int id, [FromBody] WorkTimeUpdateInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.UpdateWorkTime(id, _mapper.Map<WorkTimeModel>(workTime));
            return NoContent();
        }
         
        //api/workTimes/77
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.DeleteWorkTime(id);
            return NoContent();
        }

        //api/workTimes/77
        [HttpPatch("{id}")]
        public IActionResult RestoreWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.RestoreWorkTime(id);
            return Ok();
        }
    }
}
