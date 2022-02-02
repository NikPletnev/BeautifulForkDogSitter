using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Sitter
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

        [Required]
        public int PassportId { get; set; }
        public virtual Passport Passport { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Information { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Order> Orders { get; set; } 
        public virtual ICollection<Serviсe> Service { get; set; }
        public virtual ICollection<WorkTime> WorkTime { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
