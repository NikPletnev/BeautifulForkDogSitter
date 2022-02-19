using DogSitter.DAL.Enums;
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
        public Role Role { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<Contact> Contacts { get; set; }

        public override bool Equals(object obj)
        {

            return obj is Admin admin &&
                   Id == admin.Id &&
                   Password == admin.Password &&
                   FirstName == admin.FirstName &&
                   LastName == admin.LastName &&
                   IsDeleted == admin.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Password}";
        }

    }
}
