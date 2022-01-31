using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
