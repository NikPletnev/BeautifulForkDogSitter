using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : Controller
    {
        private DogService _service = new DogService();

        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            _service.DeleteDog(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult RestoreDog(int id)
        {
            _service.RestoreDog(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDog(int id, DogModel dog)
        {
            _service.UpdateDog(id, dog);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<DogModel> AddDog(DogModel dog)
        {
            _service.AddDog(dog);
            return StatusCode(StatusCodes.Status201Created, dog);
        }

        [HttpGet("{id}")]
        public ActionResult<DogModel> GetDogById(int id)
        {
            //if dog exist
            var dog = _service.GetDogById(id);
            return Ok(dog);
            //if dog not found
            return NotFound($"Dog {id} not found");
        }

        [HttpGet]
        public ActionResult<List<DogModel>> GetAllDogs()
        {
            var dogs = _service.GetAllDogs();
            return Ok(dogs);
        }
    }
}
