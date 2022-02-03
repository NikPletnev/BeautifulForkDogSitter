using DogSitter.DAL.Entity;

namespace DogSitter.BLL.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekdays { get; set; }
        public virtual List<Sitter> Sitter { get; set; }
    }
}
