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
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int? Mark { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Customer Customer { get; set; }
        public virtual Sitter Sitter { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual List<Dog> Dogs { get; set; }
        public virtual List<Serviсe> ServiceList { get; set; }

    }
}
