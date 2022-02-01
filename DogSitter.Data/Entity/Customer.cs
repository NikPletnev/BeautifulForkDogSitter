using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Customer : User
    {
        public virtual ICollection<Dog> Dogs { get; set; }
        public virtual ICollection<Sitter> Sitter { get; set;}
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
