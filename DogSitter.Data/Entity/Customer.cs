using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Dog> Dogs { get; set; }
        public virtual List<Sitter> Sitter { get; set;}
        public virtual Address Address { get; set; }


    }
}
