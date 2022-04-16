using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Timesheet
    {
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public Weekday Weekday { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Timesheet timesheet &&
                   Id == timesheet.Id &&
                   Start == timesheet.Start &&
                   End == timesheet.End &&
                   Weekday == timesheet.Weekday &&
                   IsDeleted == timesheet.IsDeleted &&
                   EqualityComparer<Sitter>.Default.Equals(Sitter, timesheet.Sitter);
        }
    }
}
