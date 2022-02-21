using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class DogUpdateInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range (1,100)]
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
    }
}
