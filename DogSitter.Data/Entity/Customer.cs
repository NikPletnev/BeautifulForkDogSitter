namespace DogSitter.DAL.Entity
{
    public class Customer : User
    {
        public virtual ICollection<Dog> Dogs { get; set; }
        public virtual ICollection<Sitter> Sitter { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

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
                   Address == other.Address &&
                   IsDeleted == other.IsDeleted;
        }

    }
}
