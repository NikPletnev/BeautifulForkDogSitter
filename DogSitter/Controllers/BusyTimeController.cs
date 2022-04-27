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
    public class BusyTimeController : Controller
    {
        private readonly IBusyTimeService _busyTimeService;
        private readonly IMapper _mapper;

        public BusyTimeController(IBusyTimeService busyTimeService, IMapper mapper)
        {
            _busyTimeService = busyTimeService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add busy time")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(201, "Created", typeof(ServiceOutputModel))]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult<TimesheetOutputModel> AddBusyTime([FromBody] BusyTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            int id = _busyTimeService.AddBusyTime(userId.Value, _mapper.Map<BusyTimeModel>(workTime));

            return StatusCode(StatusCodes.Status201Created, id);
        }

        //api/workTim/77
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update busy time")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult UpdateBusyTime(int id, [FromBody] BusyTimeInsertInputModel workTime)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _busyTimeService.UpdateBusyTime(userId.Value, id, _mapper.Map<BusyTimeModel>(workTime));

            return NoContent();
        }

        //api/workTime/77
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete busy time")]
        [AuthorizeRole(Role.Sitter)]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteBusyTime(int id)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _busyTimeService.DeleteBusyTime(userId.Value, id);

            return NoContent();
        }

        
    }
}
