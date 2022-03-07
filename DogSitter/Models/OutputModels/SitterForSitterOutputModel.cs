namespace DogSitter.API.Models.OutputModels
{
    public class SitterForSitterOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Raiting { get; set; }
        public List<WorkTimeOutputModel> WorkTimes { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
    }
}
