using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class ChangePasswordInputModel
    {
        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string PasswordConfirm { get; set; }
    }
}
