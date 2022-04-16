using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Sitter : User
    {
        [Required]
        public int PassportId { get; set; }
        public int AddressId { get; set; }
        public string Information { get; set; }
        public double Rating { get; set; }
        public bool Verified { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Serviсe> Services { get; set; }
        public virtual ICollection<BusyTime> BusyTime { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
        public virtual SubwayStation SubwayStation { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Sitter sitter &&
                   Id == sitter.Id &&
                   Password == sitter.Password &&
                   FirstName == sitter.FirstName &&
                   LastName == sitter.LastName &&
                   IsDeleted == sitter.IsDeleted &&
                   PassportId == sitter.PassportId &&
                   AddressId == sitter.AddressId &&
                   Information == sitter.Information &&
                   Rating == sitter.Rating &&
                   Verified == sitter.Verified;
        }
    }
}
