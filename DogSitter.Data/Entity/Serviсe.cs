using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DogSitter.DAL.Entity
{
    public class Serviсe : IEquatable<Serviсe>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Serviсe);
        }

        public bool Equals(Serviсe other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Price == other.Price &&
                   DurationHours == other.DurationHours &&
                   IsDeleted == other.IsDeleted;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description, Price, DurationHours, IsDeleted, Orders, Sitters);
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {DurationHours}";
        }
    }
}
