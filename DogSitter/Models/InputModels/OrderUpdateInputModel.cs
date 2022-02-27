using DogSitter.BLL.Models;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public CustomerModel Customer { get; set; }
        public SitterModel Sitter { get; set; }
        public WorkTimeModel SitterWorkTime { get; set; }
        public DogModel Dog { get; set; }
        public List<ServiceModel> Services { get; set; }
    }
}

