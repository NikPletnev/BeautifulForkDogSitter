using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
        public double Weight { get; set; }
        public string? Description { get; set; }
        public string Breed { get; set; }
        public Customer Customer { get; set; }

    }
}
