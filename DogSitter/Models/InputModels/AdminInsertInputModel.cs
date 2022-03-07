using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AdminInsertInputModel
    {
        //добавление
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }

        [Required]
        [TextOnly]
        public string FirstName { get; set; }

        [Required]
        [TextOnly]
        public string LastName { get; set; }

        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
    }
}
