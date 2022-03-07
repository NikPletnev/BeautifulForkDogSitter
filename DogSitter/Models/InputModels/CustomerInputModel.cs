

using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class CustomerInputModel
    {
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
        public List<DogInsertInputModel> Dogs { get; set; }
        public AddressInputModel Address { get; set; }
    }
}
