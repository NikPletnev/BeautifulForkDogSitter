using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public virtual ContactType ContactType { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override string ToString()
        {
            return $"{Id} {Value}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Contact)
            {
                return false;
            }
            if (Id != ((Contact)obj).Id
                || Value != ((Contact)obj).Value
                || IsDeleted != ((Contact)obj).IsDeleted)
                //|| ContactType.Id != ((Contact)obj).ContactType.Id
                //|| ContactType.Name != ((Contact)obj).ContactType.Name)
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
