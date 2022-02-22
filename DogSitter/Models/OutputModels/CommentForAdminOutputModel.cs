namespace DogSitter.API.Models
{
    public class CommentForAdminOutputModel
    {
        public CustomerOutputModel Customer { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
