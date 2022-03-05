using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class SubwayStationInputModel
    {
        [Required(ErrorMessage = "Укажите станцию метро")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
