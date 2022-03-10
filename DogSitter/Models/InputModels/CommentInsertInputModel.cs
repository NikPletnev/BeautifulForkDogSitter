using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class CommentInsertInputModel
    {
        [Required]
        [TextOnly]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
