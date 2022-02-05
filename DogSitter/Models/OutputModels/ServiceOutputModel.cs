namespace DogSitter.API.Models
{
    public class ServiceOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
        public List<OrderUpdateInputModel> Orders { get; set; }
        public List<SitterUpdateInputModel> Sitters { get; set; }
    }
}
