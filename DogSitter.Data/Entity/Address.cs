using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public  class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }   
        public string Apartament { get; set; }
        public List<SubwayStation> SubwayStations { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
