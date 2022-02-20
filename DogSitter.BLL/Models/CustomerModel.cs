namespace DogSitter.BLL.Models
{
    public class CustomerModel : UserModel
    {
        public List<DogModel> Dogs { get; set; }
        public List<SitterModel> Sitter { get; set; }
        public AddressModel Address { get; set; }
        public List<OrderModel> Orders { get; set; }

    }
}
