namespace DogSitter.API.Models
{
    public class ServiceOutputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
        public List<SitterOutputModel> Sitters { get; set; }
    }
}
