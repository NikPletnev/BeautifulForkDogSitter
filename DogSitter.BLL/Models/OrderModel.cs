namespace DogSitter.BLL.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int? Mark { get; set; }
        public bool IsDeleted { get; set; }
        public Customer Customer { get; set; }
        public Sitter Sitter { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public List<Dog> Dogs { get; set; }
        public List<Serviсe> Service { get; set; }
    }
}