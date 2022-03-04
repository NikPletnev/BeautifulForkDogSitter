using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int SitterId { get; set; }
        public int SitterWorkTimeId { get; set; }
        public int DogId { get; set; }
        public List<int> ServicesId { get; set; }
    }
}

