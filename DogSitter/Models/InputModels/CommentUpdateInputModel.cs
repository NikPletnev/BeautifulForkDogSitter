using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class CommentUpdateInputModel
    {
        [Required]
        public string Text { get; set; }
    }
}
