using DogSitter.BLL.Helpers.Time;
using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Models
{
    public class BusyTimeModel
    {
        public int Id { get; set; }
        public TimeRange TimeRange {get; set;}
        public Weekday Weekday { get; set; }
        public SitterModel Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BusyTimeModel model &&
                   Id == model.Id &&
                   EqualityComparer<TimeRange>.Default.Equals(TimeRange, model.TimeRange) &&
                   Weekday == model.Weekday &&
                   EqualityComparer<SitterModel>.Default.Equals(Sitter, model.Sitter);
        }
    }
}
