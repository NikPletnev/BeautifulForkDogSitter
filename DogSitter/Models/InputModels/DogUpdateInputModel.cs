namespace DogSitter.API.Models
{
    public class DogUpdateInputModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
    }
}
