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
        public WorkTimeModel SitterWorkTime { get; set; }
        public DogModel Dog { get; set; }
        public List<ServiceModel> Services { get; set; }
        public CommentModel Comment { get; set; }
    }
}