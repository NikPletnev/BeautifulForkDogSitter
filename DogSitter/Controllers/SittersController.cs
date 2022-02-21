using AutoMapper;
using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.API.Attribute;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : Controller
    {
        private readonly ISitterService _service;
        private readonly IMapper _mapper;

        public SittersController(ISitterService sitterService, IMapper mapper)
        {
            _service = sitterService;
            _mapper = mapper;
        }

        //api/sitters       
        [HttpGet("{id}")]
        public ActionResult<SitterOutputModel> GetbyId(int id)
        {
            var sitter = _service.GetById(id);
            var sitterModel = _mapper.Map<SitterOutputModel>(sitter);
            return Ok(sitterModel);
        }

        [HttpGet]
        public ActionResult<List<SitterOutputModel>> GetAll(int id)
        {
            var sitters = _service.GetAll();
            var sittersModel = _mapper.Map<SitterOutputModel>(sitters);
            return Ok(sittersModel);
        }

        [HttpPost]
        public ActionResult Add ([FromBody] SitterInsertInputModel sittetModel)
        {
            var sitter = _mapper.Map<SitterModel>( sittetModel);
            _service.Add(sitter);
            return StatusCode(StatusCodes.Status201Created, sitter);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] SitterUpdateInputModel sitterModel)
        {
            var sitter = _mapper.Map<SitterModel>(sitterModel);
            _service.Update(sitter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult Restore(int id)
        {
            _service.Restore(id);
            return Ok();
        }
    }
}
