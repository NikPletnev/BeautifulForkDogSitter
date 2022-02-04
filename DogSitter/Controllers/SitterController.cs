using DogSitter.API.Configs;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitterController : ControllerBase
    {
        private readonly SitterService _service;
        private readonly CustomMapper _mapper;
        public SitterController()
        {
            _service = new SitterService();
            _mapper = new CustomMapper();
        }

        //api/sitter/27
        [HttpGet("{id}")]
        public ActionResult<SitterOutputModel> GetbyId(int id)
        {
            var sitter = _service.GetById(id);
            var sitterModel = _mapper.GetInstance().Map<SitterOutputModel>(sitter);
            //if sitter exist
            return Ok(sitterModel);
            //if admin not found
            return NotFound($"Sitter {id} not found");
        }

        //api/sitters
        [HttpGet]
        public ActionResult<List<SitterOutputModel>> GetAll(int id)
        {
            var sitters = _service.GetAll();
            var sittersModel = _mapper.GetInstance().Map<SitterOutputModel>(sitters);
            return Ok(sittersModel);
        }

        [HttpPost]
        public ActionResult<SitterOutputModel> Add ([FromBody] SitterInsertInputModel sittetModel)
        {        
            var sitter = _mapper.GetInstance().Map<SitterModel>( sittetModel);
            _service.Add(sitter);
            return StatusCode(StatusCodes.Status201Created, sitter);
        }
        //api/sitter/27
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] SitterUpdateInputModel sitterModel)
        {
            var sitter = _mapper.GetInstance().Map<SitterModel>(sitterModel);
            _service.Update(sitter);
            return NoContent();
        }

        //api/sitter/27
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return NoContent();
        }

        //api/sitter/27
        [HttpPatch("{id}")]
        public IActionResult RestoreAdmin(int id)
        {
            _service.Restore(id);
            return Ok();
        }
    }
}
