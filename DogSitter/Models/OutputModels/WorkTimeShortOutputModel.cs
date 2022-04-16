using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class WorkTimeShortOutputModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekday { get; set; }
        public bool IsBusy { get; set; }
    }
}
