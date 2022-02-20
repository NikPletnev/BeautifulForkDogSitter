using AutoMapper;
using DogSitter.API.Models.InputModels;
using DogSitter.API.Models.OutputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
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

        [HttpGet]
        public ActionResult<List<CommentOutputModel>> GetAllComments()
        {
            var comments = _service.GetAll();
            return Ok(_mapper.Map<CommentOutputModel>(comments));
        }

        [HttpGet("{id")]
        public ActionResult<CommentOutputModel> GetCommentById(int id)
        {
            var comments = _service.GetById(id);
            return Ok(_mapper.Map<CommentOutputModel>(comments));
        }

        [HttpPost]
        public ActionResult AddComment([FromBody] CommentInsertInputModel comment)
        {
            _service.Add(_mapper.Map<CommentModel>(comment));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<CommentOutputModel>(comment));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateComment([FromRoute] int id, [FromBody] CommentUpdateInputModel commnt)
        {
            _service.Update(_mapper.Map<CommentModel>(commnt));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }
    }
}
