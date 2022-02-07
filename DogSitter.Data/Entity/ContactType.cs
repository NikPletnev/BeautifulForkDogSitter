using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class ContactType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not ContactType)
            {
                return false;
            }
            if (Id != ((ContactType)obj).Id
                || Name != ((ContactType)obj).Name
                || IsDeleted != ((ContactType)obj).IsDeleted)
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
