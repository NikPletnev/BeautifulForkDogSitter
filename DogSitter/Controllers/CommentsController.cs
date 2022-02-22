using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.OutputModels;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

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
