namespace DogSitter.API.Models
{
    public class SitterOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Raiting { get; set; }
        public string Information { get; set; }
        public AddressOutputModel Address { get; set; }
        public List<CustomerOutputModel> Customers { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
        public List<ServiceOutputModel> Services { get; set; }
        public List<TimesheetOutputModel> Timesheets { get; set; }
        public List<BusyTimeOutputModel> BusyTimes { get; set; }

    }
}