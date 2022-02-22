namespace DogSitter.API.Models.InputModels
{
    public class OrderUpdateCommentAndMarkModel
    {
        public int Mark { get; set; }
        public CommentInsertInputModel comment { get; set; }
    }
}
