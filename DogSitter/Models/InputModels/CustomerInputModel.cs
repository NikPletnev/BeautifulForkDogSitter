

using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class CustomerInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(4, 20)]
        public string Password { get; set; }
        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
        public List<DogInsertInputModel> Dogs { get; set; }
        public AddressInputModel Address { get; set; }
    }
}
