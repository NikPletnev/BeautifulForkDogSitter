using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ResetPasswordInputModel
    {
        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
