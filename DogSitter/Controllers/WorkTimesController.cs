using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

        [HttpPost]
        [Description("Add work time")]
        [AuthorizeRole(Role.Sitter)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.AddWorkTime(userId.Value, _mapper.Map<WorkTimeModel>(workTime));

            return _mapper.Map<WorkTimeOutputModel>(workTime);
        }

        //api/workTim/77
        [HttpPut("{id}")]
        [Description("Update work time")]
        [AuthorizeRole(Role.Sitter)]
        [ProducesResponseType(typeof(ServiceOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
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
        [HttpDelete("{id}")]
        [Description("Delete work time")]
        [AuthorizeRole(Role.Sitter)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
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
        [HttpPatch("{id}")]
        [Description("Restore work time")]
        [AuthorizeRole(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        public IActionResult RestoreWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _workTimeService.RestoreWorkTime(id);

            return NoContent();
        }
    }
}
