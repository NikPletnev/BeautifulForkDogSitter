using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class AuthInputModel
    {
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
