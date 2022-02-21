using DogSitter.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class WorkTimeInsertInputModel
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public Weekday Weekday { get; set; }
    }
}
