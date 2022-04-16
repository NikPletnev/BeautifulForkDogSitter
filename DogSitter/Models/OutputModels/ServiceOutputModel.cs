namespace DogSitter.API.Models
{
    public class ServiceOutputModel : ServiceShortOutputModel
    {
        public List<OrderOutputModel> Orders { get; set; }
        public List<SitterOutputModel> Sitters { get; set; }
    }
}
