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
        public Login? Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Email ContactEmail { get; set; }
        public Phone ContactPhone { get; set; }
        public List<Dog> Dogs { get; set; }
        public List<Sitter> {get; set;}
        public Address Address { get; set; }

    }
}
