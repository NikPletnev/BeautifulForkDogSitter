using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Customer : IEquatable<Customer>
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
        public virtual ICollection<Sitter> Sitter { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Customer);
        }

        public bool Equals(Customer other)
        {
            return other != null &&
                   Id == other.Id &&
                   Password == other.Password &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   IsDeleted == other.IsDeleted;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Password);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(Contacts);
            hash.Add(IsDeleted);
            hash.Add(Dogs);
            hash.Add(Sitter);
            hash.Add(Address);
            hash.Add(Orders);
            return hash.ToHashCode();
        }
    }
}
