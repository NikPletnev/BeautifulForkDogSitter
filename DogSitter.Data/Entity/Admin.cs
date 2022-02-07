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

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Password}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Admin)
            {
                return false;
            }
            if (Id != ((Admin)obj).Id
                || FirstName != ((Admin)obj).FirstName
                || LastName != ((Admin)obj).LastName
                || Password != ((Admin)obj).Password
                || IsDeleted != ((Admin)obj).IsDeleted)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
