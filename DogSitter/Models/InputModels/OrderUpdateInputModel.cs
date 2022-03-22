using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int SitterId { get; set; }
        public int SitterWorkTimeId { get; set; }
        public int DogId { get; set; }
        public List<int> ServicesId { get; set; }
    }
}

