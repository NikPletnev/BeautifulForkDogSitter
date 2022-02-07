using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class ContactType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ContactType type &&
                   Id == type.Id &&
                   Name == type.Name &&
                   IsDeleted == type.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }

        
    }
}
