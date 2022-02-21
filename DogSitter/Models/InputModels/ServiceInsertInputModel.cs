using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ServiceInsertInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double DurationHours { get; set; }
    }
}
