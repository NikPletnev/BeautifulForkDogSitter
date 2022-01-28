using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public Sitter Sitter { get; set; }
        public List<Pet> Pets { get; set; }
        public decimal Price { get; set; }
        public List<Servise> ServiceList { get; set; }
        public Comment Comment { get; set; }
        public int Mark { get; set; }
    }
}
