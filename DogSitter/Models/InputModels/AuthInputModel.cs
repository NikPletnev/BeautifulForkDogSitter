using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class AuthInputModel
    {
        [Required]
        public string Contact { get; set; }
        [Required]
        [Range(4, 20)]
        public string Password { get; set; }
    }
}
