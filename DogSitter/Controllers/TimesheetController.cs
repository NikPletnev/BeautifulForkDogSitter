using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesheetController : Controller
    {
        private readonly ITimesheetService _timesheetService;
        private readonly IMapper _mapper;

        public TimesheetController(ITimesheetService timesheetService, IMapper mapper)
        {
            _timesheetService = timesheetService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add timesheet")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(201, "Created", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<TimesheetOutputModel> AddWorkTime([FromBody] TimesheetInsertInputModel timesheet)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }
            var model = _mapper.Map<TimesheetModel>(timesheet);

            int id = _timesheetService.AddTimesheet(userId.Value, model);

            return StatusCode(StatusCodes.Status201Created, id);
        }

        //api/workTim/77
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update timesheet")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateWorkTime(int id, [FromBody] TimesheetInsertInputModel timesheet)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _timesheetService.UpdateTimesheet(userId.Value, id, _mapper.Map<TimesheetModel>(timesheet));

            return NoContent();
        }

        //api/workTime/77
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete timesheet")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _timesheetService.DeleteTimesheet(userId.Value, id);

            return NoContent();
        }

        //api/workTime/77
        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Restore timesheet")]
        [AuthorizeRole(Role.Admin)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult RestoreWorkTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _timesheetService.RestoreTimesheet(id);

            return NoContent();
        }
    }
}
