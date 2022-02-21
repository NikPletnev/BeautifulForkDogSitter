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
    public class WorkTimesController : Controller
    {
        private readonly IWorkTimeService _workTimeService;
        private readonly IMapper _mapper;

        public WorkTimesController(IWorkTimeService workTimeService, IMapper mapper)
        {
            _workTimeService = workTimeService;
            _mapper = mapper;
        }

        //api/workTime/77
        [HttpGet("{id}")]
        public ActionResult<WorkTimeOutputModel> GetWorkTimeById(int id)
        {
            var workTime = _mapper.Map<WorkTimeOutputModel>(_workTimeService.GetWorkTimeById(id));

            return Ok(workTime);
        }

        [AuthorizeRole(Role.Sitter)]
        [HttpPost]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            _workTimeService.AddWorkTime(_mapper.Map<WorkTimeModel>(workTime));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<WorkTimeOutputModel>(workTime));
        }

        //api/workTim/77
        [AuthorizeRole(Role.Sitter)]
        [HttpPut("{id}")]
        public IActionResult UpdateWorkTime(int id, [FromBody] WorkTimeUpdateInputModel workTime)
        {
            _workTimeService.UpdateWorkTime(id, _mapper.Map<WorkTimeModel>(workTime));

            return NoContent();
        }

        //api/workTime/77
        [AuthorizeRole(Role.Sitter)]
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkTime(int id)
        {
            _workTimeService.DeleteWorkTime(id);

            return NoContent();
        }

        //api/workTime/77
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("{id}")]
        public IActionResult RestoreWorkTime(int id)
        {
            _workTimeService.RestoreWorkTime(id);

            return Ok();
        }
    }
}
