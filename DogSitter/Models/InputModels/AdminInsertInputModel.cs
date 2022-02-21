

using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AdminInsertInputModel
    {
        //добавление
        [Required]
        [Range (4, 20)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<ContactInsertInputModel> Contacts { get; set; }
    }
}
