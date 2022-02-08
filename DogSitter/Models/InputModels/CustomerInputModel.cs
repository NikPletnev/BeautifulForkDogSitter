

namespace DogSitter.API.Models
{
    public class CustomerInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactUpdateInputModel> Contacts { get; set; }
        public List<DogInsertInputModel> Dogs { get; set; }
        public List<SitterInputModel> Sitter { get; set; }
        public List<AddressInputModel> Addresses { get; set; }
        public List<OrderInputModel> Orders { get; set; }
    }
}
