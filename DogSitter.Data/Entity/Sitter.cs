using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Sitter
    {
        public int Id { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Address Address { get; set; }
        public string Information { get; set; }
        public double Rating { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Order> Orders { get; set; } 
        public virtual List<Serviсe> ServiceList { get; set; }
        public virtual List<WorkTime> WorkTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
