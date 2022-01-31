using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Serviсe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double DurationHours { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Sitter> Sitters { get; set; } 
    }
}
