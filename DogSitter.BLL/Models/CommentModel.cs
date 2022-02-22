namespace DogSitter.BLL.Models
{
    public class CommentModel
    {
        public CustomerModel Customer { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}