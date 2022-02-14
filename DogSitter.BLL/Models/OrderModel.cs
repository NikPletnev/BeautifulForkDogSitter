using DogSitter.DAL.Entity;
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
        public CustomerModel Customer { get; set; }
        public SitterModel Sitter { get; set; }
        public DogModel Dogs { get; set; }
        public virtual List<ServiceModel> Service { get; set; }
        public Comment Comment { get; set; }
    }
}