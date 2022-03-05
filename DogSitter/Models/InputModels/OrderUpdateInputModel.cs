using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }

        [Range(0, 5, ErrorMessage = "Недопустимая оценка")]
        public int Mark { get; set; }
    }
}
