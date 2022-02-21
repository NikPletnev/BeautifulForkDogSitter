using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class WorkTimeUpdateInputModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekday { get; set; }
    }
}
