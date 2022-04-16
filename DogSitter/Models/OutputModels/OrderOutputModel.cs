using DogSitter.API.Models.OutputModels;
using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;

namespace DogSitter.API.Models
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int? Mark { get; set; }
        public bool IsDeleted { get; set; }
        public SitterOutputModel Sitter { get; set; }
        public BusyTimeModel SitterBusyTime { get; set; }
        public DogOutputModel Dog { get; set; }
        public List<ServiceOutputModel> Services { get; set; }
        public CommentOutputModel Comment { get; set; }
    }
}
