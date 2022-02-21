

namespace DogSitter.API.Models
{
    public class CustomerInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
        public List<DogInsertInputModel> Dogs { get; set; }
        public AddressInputModel Address { get; set; }
    }
}
