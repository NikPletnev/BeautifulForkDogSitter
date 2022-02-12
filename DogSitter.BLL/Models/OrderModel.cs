using DogSitter.DAL.Enums;

namespace DogSitter.BLL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int? Mark { get; set; }
        public bool IsDeleted { get; set; }
    }
}