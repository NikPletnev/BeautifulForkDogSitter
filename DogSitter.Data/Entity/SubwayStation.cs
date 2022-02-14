using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class SubwayStation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Sitter> Sitters { get; set; }
    }
}
