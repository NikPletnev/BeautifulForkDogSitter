using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Customer 
    {
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
        public virtual ICollection<Sitter> Sitter { get; set;}
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
