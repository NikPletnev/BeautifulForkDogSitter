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
        public Passport Passport { get; set; }
        public Address Address { get; set; }
        public string Information { get; set; }
        public double Raiting { get; set; }
        public List<Order> Orders { get; set; } 
        public List<Serviсe> ServiceList { get; set; }
        public List<WorkTime> WorkTime { get; set; }

    }
}
