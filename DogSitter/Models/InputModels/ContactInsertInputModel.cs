using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class ContactInsertInputModel
    {
        [Required]
        public string Value { get; set; }

        [Required]
        [RegularExpression(@"^(Phone|Mail)$")]
        public string ContactType { get; set; }
    }
}
