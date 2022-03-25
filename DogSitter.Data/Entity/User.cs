using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public Role Role { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}
