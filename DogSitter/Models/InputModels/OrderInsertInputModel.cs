using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class OrderInsertInputModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Недопустимая цена")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 6, ErrorMessage = "Недопустимый статус")]
        public Status Status { get; set; }

        [Range(0, 5, ErrorMessage = "Недопустимая оценка")]
        public int Mark { get; set; }
        

    }
}


