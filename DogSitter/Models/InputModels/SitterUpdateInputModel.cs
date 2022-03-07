using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class SitterUpdateInputModel
    {
        [Required]
        [TextOnly]
        public string FirstName { get; set; }

        [Required]
        [TextOnly]
        public string LastName { get; set; }
        public int SubwayStationId { get; set; }
        public string Information { get; set; }
    }
}
