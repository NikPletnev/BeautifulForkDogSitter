using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:Controller
    {
        private readonly IAuthService _authService; 

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("loginAdmin")]
        public ActionResult LoginAdmin([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.LoginAdmin(authInputModel.Contact, authInputModel.Password);
            return Json(token);
        }


    }
}
