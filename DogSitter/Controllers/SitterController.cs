using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitterController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<Sitter> GetbyId(int id)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Sitter>> GetAll(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Add(SitterModel sittetModel)
        {            
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(SitterModel sitterModel)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
