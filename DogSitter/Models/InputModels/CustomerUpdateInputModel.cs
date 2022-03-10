using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class CustomerUpdateInputModel
    {
        [Required]
        [TextOnly]
        public string FirstName { get; set; }
        [Required]
        [TextOnly]
        public string LastName { get; set; }
        public AddressInputModel Address { get; set; }

    }
}
