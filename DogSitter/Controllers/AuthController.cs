using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login/admin")]
        public ActionResult LoginAdmin([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.GetToken(_authService.GetAdminForLogin(authInputModel.Contact,
                authInputModel.Password));

            return Json(token);
        }

        [HttpPost("login/sitter")]
        public ActionResult LoginSitter([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.GetToken(_authService.GetSitterForLogin(authInputModel.Contact,
                authInputModel.Password));

            return Json(token);
        }

        [HttpPost("login/customer")]
        public ActionResult LoginCustomer([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.GetToken(_authService.GetCustomerForLogin(authInputModel.Contact, 
                authInputModel.Password));

            return Json(token);
        }

    }
}
