using DogSitter.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class WorkTimeUpdateInputModel
    {
        [Required(ErrorMessage = "Укажите время начала работы")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:MM}")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Укажите время окончания работы")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:MM}")]
        public DateTime End { get; set; }

        [Display(Name = "День недели")]
        [Range(1, 7)]
        public Weekday Weekday { get; set; }
    }
}
