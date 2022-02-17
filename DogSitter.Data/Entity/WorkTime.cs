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
        public bool IsDeleted { get; set; }
        public virtual ICollection<Sitter> Sitter { get; set; }
    }
}
