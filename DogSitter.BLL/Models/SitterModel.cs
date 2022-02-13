namespace DogSitter.BLL.Models
{
    public class SitterModel : UserModel
    {
        public List <SubwayStationModel> SubwayStations { get; set; }
        public double Rating { get; set; }
        public string Information { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<ServiceModel> Services { get; set; }
        public List<WorkTimeModel> WorkTime { get; set; }
        public List<CustomerModel> Customers { get; set; }
    }
}
