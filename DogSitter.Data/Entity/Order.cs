using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }
        public int? Mark { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        public virtual Sitter Sitter { get; set; }
        public virtual BusyTime SitterWorkTime { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual ICollection<Serviсe> Service { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   Id == order.Id &&
                   OrderDate == order.OrderDate &&
                   Price == order.Price &&
                   Status == order.Status &&
                   Mark == order.Mark &&
                   IsDeleted == order.IsDeleted &&
                   CommentId == order.CommentId;
        }
    }
}
