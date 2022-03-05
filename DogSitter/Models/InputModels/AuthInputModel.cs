using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class AuthInputModel
    {
        [Required]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
