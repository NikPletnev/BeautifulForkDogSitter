using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class ChangePasswordInputModel
    {
        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string PasswordConfirm { get; set; }
    }
}
