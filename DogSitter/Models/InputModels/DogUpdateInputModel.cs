using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class DogUpdateInputModel
    {
        [Required]
        [TextOnly]
        public string Name { get; set; }

        [Required]
        [Range(0, 30, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Недопустимый вес")]
        public double Weight { get; set; }

        [TextOnly]
        public string Description { get; set; }

        [Required]
        [TextOnly]
        public string Breed { get; set; }
    }
}
