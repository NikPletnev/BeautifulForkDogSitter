using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class BusyTime
    {
        public int Id { get; set; }
        [Required]
        public TimeOnly Start { get; set; }
        [Required]
        public TimeOnly End { get; set; }
        [Required]
        public Weekday Weekday { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is BusyTime time &&
                   Id == time.Id &&
                   Start == time.Start &&
                   End == time.End &&
                   Weekday == time.Weekday &&
                   EqualityComparer<Sitter>.Default.Equals(Sitter, time.Sitter);
        }
    }
}
