using DogSitter.BLL.Helpers.Time;
using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class BusyTimeOutputModel
    {
        public int Id { get; set; }
        public TimeRange TimeRange { get; set; }
        public Weekday Weekday { get; set; }

    }
}
