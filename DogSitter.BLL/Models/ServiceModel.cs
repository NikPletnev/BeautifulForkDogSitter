namespace DogSitter.BLL.Models
{
    public class ServiceModel : IEquatable<ServiceModel>
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
            return Equals(obj as ServiceModel);
        }

        public bool Equals(ServiceModel other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Price == other.Price &&
                   DurationHours == other.DurationHours &&
                   EqualityComparer<List<OrderModel>>.Default.Equals(Orders, other.Orders) &&
                   EqualityComparer<List<SitterModel>>.Default.Equals(Sitters, other.Sitters);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description, Price, DurationHours, Orders, Sitters);
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {DurationHours}";
        }
    }
}
