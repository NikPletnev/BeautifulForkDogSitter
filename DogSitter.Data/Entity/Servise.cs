namespace DogSitter.DAL.Entity
{
    public class Servise
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
    }
}
