
using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AddressInputModel
    {
        [Required]
        [TextOnly]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [TextOnly] 
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите улицу")]
        [TextOnly]
        public string Street { get; set; }

        [Required(ErrorMessage = "Укажите номер дома")]
        [Range(1, 1000, ErrorMessage = "Неверный номер дома")]
        public int House { get; set; }

        [Required(ErrorMessage = "Укажите номер квартиры")]
        [Range(1, 1000, ErrorMessage = "Неверный номер квартры")]
        public int Apartament { get; set; }

        [Range(1, 72)]
        public List<int> SubwayStationsId { get; set; }
    }
}
