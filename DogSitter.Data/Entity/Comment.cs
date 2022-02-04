using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Order Order { get; set; }
    }
}
