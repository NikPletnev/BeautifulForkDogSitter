using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class SitterInsertInputModel
    {
        [Required]
        [Range (4,20)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
        public PassportInsertInputModel Passport { get; set; }
        public SubwayStationInputModel SubwayStation { get; set; }
        public string Information { get; set; }

    }
}
