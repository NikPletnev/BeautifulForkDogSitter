namespace DogSitter.API.Models.OutputModels
{
    public class SitterForSitterOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Raiting { get; set; }
        public List<TimesheetOutputModel> Timesheets { get; set; }
        public List<BusyTimeOutputModel> BusyTimes { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
        public List<ServiceOutputModel> Services { get; set; }
    }
}
