using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ContactInsertInputModel
    {
        [Required]
        public string Value { get; set; }
        [Required]
        [Range (1,2)]
        public int ContactType { get; set; }
    }
}
