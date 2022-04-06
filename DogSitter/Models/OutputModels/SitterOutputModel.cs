namespace DogSitter.API.Models
{
    public class SitterOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Raiting { get; set; }
        public string Information { get; set; }
        public AddressOutputModel Address { get; set; }
        public List<ServiceShortOutputModel> Services { get; set; }
        public List<WorkTimeShortOutputModel> WorkTimes { get; set; }
    }
}