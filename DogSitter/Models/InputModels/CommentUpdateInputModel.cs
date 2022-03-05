using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class CommentUpdateInputModel
    {
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Text { get; set; }
    }
}
