using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class CommentUpdateInputModel
    {
        [Required]
        [TextOnly]
        public string Text { get; set; }
    }
}
