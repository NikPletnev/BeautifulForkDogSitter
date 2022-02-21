using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class SubwayStationInputModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
