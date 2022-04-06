namespace DogSitter.API.Models
{
    public class SitterForAdminOutputModel : SitterOutputModel
    {
        public List<CustomerOutputModel> Customers { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
        public PassportOutputModel Passport { get; set; }
    }
}
