namespace DogSitter.DAL.Entity
{
    public class WorkTime
    {
        public int Id { get; set; }
        public Sitter Sitter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateClouse { get; set; }
        public int Weekdays { get; set; }
    }
}
