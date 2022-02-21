using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class CommentInsertInputModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
