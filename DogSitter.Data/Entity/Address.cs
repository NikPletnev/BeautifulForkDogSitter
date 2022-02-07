using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int House { get; set; }
        [Required]
        public int Apartament { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<SubwayStation> SubwayStations { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }


    }
}
