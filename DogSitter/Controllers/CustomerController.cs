using DogSitter.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult UpdateCustomer([FromBody] Customer customer)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }

}
