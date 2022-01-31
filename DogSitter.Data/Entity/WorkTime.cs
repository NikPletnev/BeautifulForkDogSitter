namespace DogSitter.DAL.Entity
{
    public class WorkTime
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Weekday Weekdays { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual Sitter Sitter { get; set; }
    }
}
