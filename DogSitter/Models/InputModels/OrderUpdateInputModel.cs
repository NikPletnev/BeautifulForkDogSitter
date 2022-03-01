using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public SitterInsertInputModel Sitter { get; set; }
        public WorkTimeInsertInputModel SitterWorkTime { get; set; }
        public DogInsertInputModel Dog { get; set; }
        public List<ServiceInsertInputModel> Services { get; set; }
    }
}

