using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Dog
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Weight { get; set; }
        public string Description { get; set; }
        [Required]
        public string Breed { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override bool Equals(object obj)
        {

            return obj is Dog dog &&
                   Id == dog.Id &&
                   Name == dog.Name &&
                   Age == dog.Age &&
                   Weight == dog.Weight &&
                   Description == dog.Description &&
                   Breed == dog.Breed &&
                   IsDeleted == dog.IsDeleted;
        }
    }
}
