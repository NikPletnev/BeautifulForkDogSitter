﻿using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.API.Models.OutputModels;
using DogSitter.BLL.Models;
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
            var comments = _service.GetAll();
            return Ok(_mapper.Map<CommentOutputModel>(comments));
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        public ActionResult AddComment([FromBody] CommentInsertInputModel comment)
        {
            _service.Add(_mapper.Map<CommentModel>(comment));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<CommentOutputModel>(comment));
        }

        [AuthorizeRole(Role.Admin)]
        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }

        [AuthorizeRole(Role.Customer, Role.Sitter)]
        [HttpGet("{sitters/id/comments}")]
        public ActionResult GetAllCommentsBySitter(int id)
        {
            var comments = _mapper.Map<List<CommentOutputModel>>(_service.GetAllCommentsBySitterId(id));
            return Ok(comments);
        }

        [AuthorizeRole(Role.Admin)]
        [HttpGet("{sitters/id/comments}")]
        public ActionResult GetAllCommentsBySitterForAdmin(int id)
        {
            var comments = _mapper.Map<List<CommentForAdminOutputModel>>(_service.GetAllCommentsBySitterId(id));
            return Ok(comments);
        }
    }
}
