namespace DogSitter.BLL.Models
{
    public class DogModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public bool IsDeleted { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
