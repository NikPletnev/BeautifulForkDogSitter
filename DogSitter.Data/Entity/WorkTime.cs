namespace DogSitter.DAL.Entity
{
    public class WorkTime
    {
        public int Id { get; set; }
        public Sitter Sitter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Weekday Weekdays { get; set; }
        public bool IsDeleted { get; set; }
    }
}
