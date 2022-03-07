
using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AddressInputModel
    {
        [Required]
        [TextOnly]
        public string Name { get; set; }

        [Required]
        [TextOnly] 
        public string City { get; set; }

        [Required]
        [TextOnly]
        public string Street { get; set; }

        [Required]
        [NumbersOnly]
        public int House { get; set; }

        [Required(ErrorMessage = "Укажите номер квартиры")]
        [Range(0, 100)]
        public int Apartament { get; set; }

        [Required(ErrorMessage = "Укажите станцию метро")]
        public List<SubwayStationInputModel> SubwayStations { get; set; }
    }
}
