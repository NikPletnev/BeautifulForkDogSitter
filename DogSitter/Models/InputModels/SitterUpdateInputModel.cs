using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class SitterUpdateInputModel
    {
        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string LastName { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
        public SubwayStationInputModel SubwayStation { get; set; }

    }
}
