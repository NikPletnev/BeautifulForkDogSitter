namespace DogSitter.API.Models
{
    public class CustomerOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactOutputModel> Contacts { get; set; }
        public List<DogOutputModel> Dogs { get; set; }
        public List<SitterOutputModel> Sitter { get; set; }
        public List<AddressOutputModel> Address { get; set; }
        public List<OrderOutputModel> Orders { get; set; }

    }
}