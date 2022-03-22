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
        [SwaggerOperation(Summary = "Add work time")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(201, "Created", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<WorkTimeOutputModel> AddWorkTime([FromBody] WorkTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            int id = _workTimeService.AddWorkTime(userId.Value, _mapper.Map<WorkTimeModel>(workTime));

            return StatusCode(StatusCodes.Status201Created, id);
        }

        //api/workTim/77
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update work time")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateWorkTime(int id, [FromBody] WorkTimeUpdateInputModel workTime)
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
        [SwaggerOperation(Summary = "Delete work time")]
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

            _workTimeService.DeleteWorkTime(userId.Value, id);

            return NoContent();
        }

        //api/workTime/77
        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Restore work time")]
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

            _workTimeService.RestoreWorkTime(id);

            return NoContent();
        }
    }
}
