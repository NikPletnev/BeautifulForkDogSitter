using DogSitter.DAL.Entity;

namespace DogSitter.API.Models
{
    public class WorkTimeOutputModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekday { get; set; }
        public List<Sitter> Sitters { get; set; }
        public bool IsBusy { get; set; }
    }
}
