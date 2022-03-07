
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AddressInputModel
    {
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Street { get; set; }
        [Required]
        [RegularExpression(@"^([1-9]\d*)?\d$")]
        public int House { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Укажите номер квартиры")]
        public int Apartament { get; set; }

        [Required(ErrorMessage = "Укажите станцию метро")]
        [StringLength(50, MinimumLength = 3)]
        public List<SubwayStationInputModel> SubwayStations { get; set; }
    }
}
