
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AddressInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int House { get; set; }
        public int Apartament { get; set; }
        [Required]
        public List<SubwayStationInputModel> SubwayStations { get; set; }
    }
}
