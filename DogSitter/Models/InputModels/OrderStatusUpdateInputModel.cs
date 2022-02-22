using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models.InputModels
{
    public class OrderStatusUpdateInputModel
    {
        [Required]
        public int OrderNewStatus { get; set; }
    }
}
