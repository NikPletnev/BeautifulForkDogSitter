using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class OrderUpdateCommentAndMarkModel
    {
        [Range(0, 5, ErrorMessage = "Недопустимая оценка")]
        public int Mark { get; set; }
        public CommentInsertInputModel Comment { get; set; }
    }
}
