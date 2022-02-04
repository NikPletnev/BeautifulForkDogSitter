using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class ContactType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
