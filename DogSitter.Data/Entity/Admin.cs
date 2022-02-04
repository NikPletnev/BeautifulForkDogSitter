using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public bool IsDeleted { get; set; }
    }
}
