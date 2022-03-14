using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class SubwayStation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Sitter> Sitters { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public override bool Equals(object obj)
        {
            return obj is SubwayStation station &&
                   Id == station.Id &&
                   Name == station.Name &&
                   IsDeleted == station.IsDeleted;
        }
    }
}
