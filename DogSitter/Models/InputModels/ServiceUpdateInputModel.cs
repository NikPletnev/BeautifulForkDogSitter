namespace DogSitter.API.Models
{
    public class ServiceUpdateInputModel : ServiceInsertInputModel
    {
        public List<OrderUpdateInputModel> Orders { get; set; }
        public List<SitterUpdateInputModel> Sitters { get; set; }
    }
}
