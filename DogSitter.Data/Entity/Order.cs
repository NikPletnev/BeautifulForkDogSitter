using DogSitter.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required]
        public virtual Sitter Sitter { get; set; }
        public int? CommentId { get; set; }    
        public virtual Comment Comment { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
        public virtual ICollection<Serviсe> Service { get; set; }

    }
}
