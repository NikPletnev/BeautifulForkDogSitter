using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ServiceInsertInputModel
    {
        [Required(ErrorMessage = "Укажите название")]
        [TextOnly]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите описание")]
        [StringLength(1000, MinimumLength = 0)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 10000, ErrorMessage = "Недопустимая цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите длительность")]
        [Range(0.5, 5.0, ErrorMessage = "Недопустимая длительность")]
        public double DurationHours { get; set; }
    }
}
