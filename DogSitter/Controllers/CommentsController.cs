using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.OutputModels;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentsController(IMapper mapper, ICommentService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet]
        [SwaggerOperation(Summary = "Get all comments")]
        [SwaggerResponse(200, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        public ActionResult<List<CommentOutputModel>> GetAllComments()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var comments = _service.GetAll();
            return Ok(_mapper.Map<CommentOutputModel>(comments));
        }

        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete comment")]
        [SwaggerResponse(204, "NoContent")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        public ActionResult DeleteComment(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.DeleteById(id);
            return NoContent();
        }

        [AuthorizeRole(Role.Customer, Role.Sitter, Role.Admin)]
        [HttpGet("sitters/{id}")]
        [SwaggerOperation(Summary = "Get comments by sitterId")]
        [SwaggerResponse(201, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        public ActionResult GetAllCommentsBySitter(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }
            if (User.IsInRole("Admin"))
            {
                var comments = _mapper.Map<List<CommentForAdminOutputModel>>(_service.GetAllCommentsBySitterId(id));
                return Ok(comments);
            }
            else
            {
                var comments = _mapper.Map<List<CommentOutputModel>>(_service.GetAllCommentsBySitterId(id));
                return Ok(comments);
            }
        }
    }
}
