namespace DogSitter.BLL.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<SitterModel> Sitters { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ServiceModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   Description == model.Description &&
                   Price == model.Price &&
                   DurationHours == model.DurationHours;
        }
    }
}
