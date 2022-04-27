using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ConfirmNewEmailInputModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
