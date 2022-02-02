using DogSitter.API.Configs;
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
        private DogService _service = new DogService();
        
        //api/dogs/42
        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            _service.DeleteDog(id);
            return NoContent();
        }

        //api/dogs/42
        [HttpPatch("{id}")]
        public IActionResult RestoreDog(int id)
        {
            _service.RestoreDog(id);
            return NoContent();
        }

        //api/dogs/42
        [HttpPut("{id}")]
        public IActionResult UpdateDog(int id, DogUpdateOutputModel dog)
        {
            _service.UpdateDog(id, CustomMapper.GetInstance().Map<DogModel>(dog));
            return NoContent();
        }

        //api/dogs
        [HttpPost]
        public ActionResult<DogInsertInputModel> AddDog(DogInsertInputModel dog)
        {
            _service.AddDog(CustomMapper.GetInstance().Map<DogModel>(dog));
            return StatusCode(StatusCodes.Status201Created, dog);
        }

        //api/dogs/42
        [HttpGet("{id}")]
        public ActionResult<DogUpdateOutputModel> GetDogById(int id)
        {
            //if dog exist
            var dog = CustomMapper.GetInstance().Map<DogModel>(_service.GetDogById(id));
            return Ok(dog);
            //if dog not found
            return NotFound($"Dog {id} not found");
        }

        [HttpGet]
        public ActionResult<List<DogUpdateOutputModel>> GetAllDogs()
        {
            var dogs = CustomMapper.GetInstance().Map < List <DogUpdateOutputModel>>(_service.GetAllDogs());
            return Ok(dogs);
        }
    }
}
