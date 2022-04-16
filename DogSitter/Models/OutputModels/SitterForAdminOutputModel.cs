namespace DogSitter.API.Models
{
    public class SitterForAdminOutputModel : SitterOutputModel
    {
        public List<CustomerOutputModel> Customers { get; set; }
        public List<OrderOutputModel> Orders { get; set; }
        public List<ServiceOutputModel> Services { get; set; }
        public List<TimesheetOutputModel> Timesheets { get; set; }
        public List<BusyTimeOutputModel> BusyTimes { get; set; }
        public PassportOutputModel Passport { get; set; }
    }
}
