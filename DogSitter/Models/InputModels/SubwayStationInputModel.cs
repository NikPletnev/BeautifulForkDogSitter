using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class SubwayStationInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
