namespace DogSitter.API.Models.OutputModels
{
    public class CommentOutputModel
    {
        int Id { get; set; }
        public string Name { get; set; } = "Анонимный отзыв";
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
