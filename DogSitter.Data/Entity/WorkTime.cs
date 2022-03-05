using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class WorkTime
    {
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public Weekday Weekday { get; set; }
        public bool IsBusy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WorkTime time &&
                   Id == time.Id &&
                   Start == time.Start &&
                   End == time.End &&
                   Weekday == time.Weekday &&
                   IsDeleted == time.IsDeleted;
        }
    }
}
