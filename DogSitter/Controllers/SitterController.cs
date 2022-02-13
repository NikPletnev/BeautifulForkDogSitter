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
    public class SitterController : ControllerBase
    {
        private ISitterService _service;
        private IMapper _mapper;

        public SitterController(ISitterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult RegistrationSitter([FromBody] SitterInsertInputModel sitter)
        {
            _service.Add(_mapper.Map<SitterModel>(sitter));
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPatch]
        public ActionResult BlockSitterProfile(int id)
        {
            _service.BlockProfileSitterById(id);
            return NoContent();
        }

        [HttpPatch]
        public ActionResult ConfirmSitterProfile(int id)
        {
            _service.ConfirmProfileSitterById(id);
            return NoContent();
        }
    }
}
