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
        public string House { get; set; }
        [Required]
        public int Apartament { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<SubwayStation> SubwayStations { get; set; }
        public virtual Customer Customer { get; set; }

        private bool Equals(Address other)
        {
            return Id == other.Id &&
                Name.Equals(other.Name) &&
                City.Equals(other.City) &&
                Street.Equals(other.Street) &&
                House.Equals(other.House) &&
                Apartament.Equals(other.Apartament) &&
                IsDeleted == other.IsDeleted;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Address)obj);
        }

        public override string ToString()
        {
            return $"{Id} {Name} {City} {Street} {House} {Apartament}";
        }

    }
}
