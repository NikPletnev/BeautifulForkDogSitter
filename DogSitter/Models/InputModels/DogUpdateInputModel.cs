using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class DogUpdateInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(0)]
        public int Age { get; set; }
        [Required]
        [MinLength(0)]
        public double Weight { get; set; }
        public string Description { get; set; }
        [Required]
        public string Breed { get; set; }
    }
}
