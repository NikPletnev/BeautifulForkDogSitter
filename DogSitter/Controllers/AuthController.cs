using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.GetToken(_authService.GetUserForLogin(authInputModel.Contact,
                authInputModel.Password));

            return Json(token);
        }

        [HttpPut("{id}/password")]
        [Description("Change password by user Id")]
        [Authorize]
        //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(typeof(ExceptionResponse), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ValidationExceptionResponse), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult ChangeUserPasswordByUserId(int id, [FromBody] ChangePasswordInputModel password)
        {
            _authService.ChangeUserPassword(id, password.NewPassword);

            return Ok();
        }
    }
}
