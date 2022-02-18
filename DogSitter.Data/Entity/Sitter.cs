using System.ComponentModel.DataAnnotations;

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
        public bool IsDeleted { get; set; }
        [Required]
        public int PassportId { get; set; }
        public int AddressId { get; set; }
        public string Information { get; set; }
        public double Rating { get; set; }
        public bool Verified { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Serviсe> Services { get; set; }
        public virtual ICollection<WorkTime> WorkTime { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual ICollection<Address> Adress { get; set; }
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
                   Rating == sitter.Rating;
        }

    }
}
