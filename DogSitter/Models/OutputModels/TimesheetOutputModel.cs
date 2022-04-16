using DogSitter.BLL.Helpers.Time;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class TimesheetOutputModel
    {
        public int Id { get; set; }
        public TimeRange TimeRange { get; set; }
        public Weekday Weekday { get; set; }

    }
}
