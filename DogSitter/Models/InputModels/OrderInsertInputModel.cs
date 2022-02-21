using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class OrderInsertInputModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }
        public int Mark { get; set; }
    }
}
