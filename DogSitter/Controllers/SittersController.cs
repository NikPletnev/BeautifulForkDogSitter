using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SittersController : ControllerBase
    {
        private ISitterService _service;
        private IMapper _mapper;

        public SittersController(ISitterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //api/sitters
        [AuthorizeRole(Role.Sitter)]
        [HttpPost]
        public ActionResult RegisterSitter([FromBody] SitterInsertInputModel sitter)
        {
            _service.Add(_mapper.Map<SitterModel>(sitter));
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/sitters/block/42
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("block/{id}")]
        public ActionResult BlockSitterProfile(int id)
        {
            _service.BlockProfileSitterById(id);
            return NoContent();
        }

        //api/sitters/confirm/42
        [AuthorizeRole(Role.Admin)]
        [HttpPatch("confirm/{id}")]
        public ActionResult ConfirmSitterProfile(int id)
        {
            _service.ConfirmProfileSitterById(id);
            return NoContent();
        }
    }
}
