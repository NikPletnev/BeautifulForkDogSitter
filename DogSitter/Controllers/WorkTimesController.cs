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
    public class WorkTimesController : Controller
    {
        private readonly IWorkTimeService _workTimeService;
        private readonly IMapper _mapper;

        public WorkTimesController(IWorkTimeService workTimeService, IMapper mapper)
        {
            _workTimeService = workTimeService;
            _mapper = mapper;
        }

        [AuthorizeRole(Role.Sitter)]
        [HttpPost]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var workTimeId = _workTimeService.AddWorkTime(userId.Value, _mapper.Map<WorkTimeModel>(workTime));

            return StatusCode(StatusCodes.Status201Created, workTimeId);
        }

        //api/workTim/77
        [AuthorizeRole(Role.Sitter)]
        [HttpPut("{id}")]
        public IActionResult UpdateWorkTime(int id, [FromBody] WorkTimeUpdateInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.UpdateWorkTime(userId.Value, id, _mapper.Map<WorkTimeModel>(workTime));

            return NoContent();
        }

        //api/workTime/77
        [AuthorizeRole(Role.Sitter)]
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.DeleteWorkTime(userId.Value, id);

            return NoContent();
        }

        //api/workTime/77
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public IActionResult RestoreWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.RestoreWorkTime(id);

            return Ok();
        }
    }
}
