using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class DogUpdateInputModel
    {
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Name { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Недопустимый вес")]
        public double Weight { get; set; }
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Breed { get; set; }
    }
}
