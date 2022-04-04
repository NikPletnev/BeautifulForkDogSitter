using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Models
{
    public class BusyTimeModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekday { get; set; }
        public SitterModel Sitter { get; set; }
        public override bool Equals(object obj)
        {
            return obj is WorkTimeModel model &&
                   Id == model.Id &&
                   Start == model.Start &&
                   End == model.End &&
                   Weekday == model.Weekday;
        }
    }
}
