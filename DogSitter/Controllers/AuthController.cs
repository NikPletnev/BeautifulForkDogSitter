using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword([FromBody] string email)
        {
            _authService.ForgotPassword(email);
            return Ok(new { message = "Please check your email for password reset instructions" });
        }

        [HttpPost("reset-password")]
        public ActionResult ResetPassword(ResetPasswordInputModel model )
        {
            _authService.ResetPassword(model.NewPassword, model.Token);
            return NoContent();
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Log In")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        public ActionResult LoginUser([FromBody] AuthInputModel authInputModel)
        {
            var token = _authService.GetToken(_authService.GetUserForLogin(authInputModel.Contact,
                authInputModel.Password));

            return Json(token);
        }

        [HttpPut("change-password")]
        [Authorize]
        [SwaggerOperation(Summary = "Change user password")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request", typeof(ExceptionResponse))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(403, "Forbidden", typeof(ExceptionResponse))]
        [SwaggerResponse(404, "NotFound", typeof(ExceptionResponse))]
        [SwaggerResponse(422, "Unprocessable Entity", typeof(ValidationExceptionResponse))]
        public ActionResult ChangeUserPassword([FromBody] ChangePasswordInputModel password)
        {
            var userId = this.GetUserId();
            if (userId is null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _authService.ChangeUserPassword(userId.Value, password.NewPassword, password.OldPassword);

            return Ok();
        }
    }
}
