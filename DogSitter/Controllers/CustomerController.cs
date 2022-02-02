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

        public ActionResult<Customer> GetAllCustomer()
        {
            return Ok();
        }


        [HttpPost("{customer}")]

        public ActionResult AddCustomer(Customer customer)
        {
            return Ok();
        }

        [HttpPut("{customer}")]

        public ActionResult UpdateCustomer(Customer customer)
        {
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteCustomer(int id)
        {
            return Ok();
        }

    }

}
