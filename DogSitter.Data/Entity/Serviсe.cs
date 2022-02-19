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

        public override bool Equals(object obj)
        {
            return obj is Serviсe serviсe &&
                   Id == serviсe.Id &&
                   Name == serviсe.Name &&
                   Description == serviсe.Description &&
                   Price == serviсe.Price &&
                   DurationHours == serviсe.DurationHours &&
                   IsDeleted == serviсe.IsDeleted;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description, Price, DurationHours, IsDeleted, Orders, Sitters);
        }
    }
}
