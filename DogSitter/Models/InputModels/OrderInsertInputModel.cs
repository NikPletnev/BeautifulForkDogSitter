using DogSitter.DAL.Enums;

namespace DogSitter.API.Models.InputModels
{
    public class OrderInsertInputModel
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public int Mark { get; set; }
    }
}
