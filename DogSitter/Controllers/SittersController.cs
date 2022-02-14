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
    public class SittersController : Controller
    {
        private readonly SitterService _service;
        private readonly CustomMapper _mapper;

        public SittersController()
        {
            _service = new SitterService();
            _mapper = new CustomMapper();
        }

        [HttpGet("{id}")]
        public ActionResult<SitterOutputModel> GetbyId(int id)
        {
            var sitter = _service.GetById(id);
            var sitterModel = _mapper.GetInstance().Map<SitterOutputModel>(sitter);
            return Ok(sitterModel);
        }

        [HttpGet]
        public ActionResult<List<SitterOutputModel>> GetAll(int id)
        {
            var sitters = _service.GetAll();
            var sittersModel = _mapper.GetInstance().Map<SitterOutputModel>(sitters);
            return Ok(sittersModel);
        }

        [HttpPost]
        public ActionResult Add ([FromBody] SitterInputModel sittetModel)
        {        
            var sitter = _mapper.GetInstance().Map<SitterModel>( sittetModel);
            _service.Add(sitter);
            return StatusCode(StatusCodes.Status201Created, sitter);
        }

        [HttpPut]
        public ActionResult Update([FromBody] SitterInputModel sitterModel)
        {
            var sitter = _mapper.GetInstance().Map<SitterModel>(sitterModel);
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
