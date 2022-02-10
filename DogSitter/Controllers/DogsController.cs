using AutoMapper;
using DogSitter.API.Models;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : Controller
    {
        private IDogService _service;
        private IMapper _map;

        public DogsController(IMapper mapper, IDogService dogService)
        {
            _service = dogService;
            _map = mapper;
        }

        ////api/dogs/42
        //[HttpDelete("{id}")]
        //public IActionResult DeleteDog(int id)
        //{
        //    _service.DeleteDog(id);
        //    return NoContent();
        //}

        ////api/dogs/42
        //[HttpPatch("{id}")]
        //public IActionResult RestoreDog(int id)
        //{
        //    _service.RestoreDog(id);
        //    return NoContent();
        //}

        //api/dogs/42
        [HttpPut("{id}")]
        public IActionResult UpdateDog(int id, [FromBody] DogUpdateInputModel dog)
        {
            _service.UpdateDog(id, _map.Map<DogModel>(dog));
            return NoContent();
        }

        //api/dogs
        [HttpPost]
        public ActionResult<DogOutputModel> AddDog([FromBody] DogInsertInputModel dog)
        {
            _service.AddDog(_map.Map<DogModel>(dog));
            return StatusCode(StatusCodes.Status201Created, _map.Map<DogOutputModel>(dog));
        }

        //api/dogs/42
        [HttpGet("{id}")]
        public ActionResult<DogOutputModel> GetDogById(int id)
        {
            //if dog exist
            var dog = _map.Map<DogOutputModel>(_service.GetDogById(id));
            return Ok(dog);
            //if dog not found
            return NotFound($"Dog {id} not found");
        }

        [HttpGet]
        public ActionResult<List<DogOutputModel>> GetAllDogs()
        {
            var dogs = _map.Map<List<DogOutputModel>>(_service.GetAllDogs());
            return Ok(dogs);
        }
    }
}
