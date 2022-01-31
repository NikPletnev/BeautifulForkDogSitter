namespace DogSitter.DAL.Entity
{
    public class Serviсe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double DurationHours { get; set; }
        public virtual Order Order { get; set; }
        public virtual Sitter Sitter { get; set; } 
        public bool IsDeleted { get; set; } = false;
    }
}
