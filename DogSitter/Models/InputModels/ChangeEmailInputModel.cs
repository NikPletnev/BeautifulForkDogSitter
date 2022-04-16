using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class ChangeEmailInputModel
    {
        [EmailAddress]
        [Required]
        public string OldEmail { get; set; }
        [EmailAddress]
        [Required]
        public string NewEmail { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
