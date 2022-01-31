using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Customer : User
    {
        public virtual List<Dog> Dogs { get; set; }
        public virtual List<Sitter> Sitter { get; set;}
        public virtual Address Address { get; set; }
    }
}
