using AutoMapper;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public ActionResult RegisterSitter([FromBody] SitterInsertInputModel sitter)
        {
            _service.Add(_mapper.Map<SitterModel>(sitter));
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/sitters/42
        [HttpPatch("{id}")]
        public ActionResult BlockSitterProfile(int id)
        {
            _service.BlockProfileSitterById(id);
            return NoContent();
        }

        //api/sitters/42
        [HttpPatch("{id}")]
        public ActionResult ConfirmSitterProfile(int id)
        {
            _service.ConfirmProfileSitterById(id);
            return NoContent();
        }
    }
}
