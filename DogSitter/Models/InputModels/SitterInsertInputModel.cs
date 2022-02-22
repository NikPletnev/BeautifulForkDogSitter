using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class SitterInsertInputModel
    {
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
        [Required]
        public PassportInsertInputModel Passport { get; set; }
        [Required]
        public SubwayStationInputModel SubwayStation { get; set; }
        public string Information { get; set; }

    }
}
