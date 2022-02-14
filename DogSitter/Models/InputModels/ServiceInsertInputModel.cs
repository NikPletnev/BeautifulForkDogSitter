namespace DogSitter.API.Models
{
    public class ServiceInsertInputModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
    }
}
