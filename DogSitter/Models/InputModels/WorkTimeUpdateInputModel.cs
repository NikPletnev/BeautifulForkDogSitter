using DogSitter.API.Attribute;
using DogSitter.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class WorkTimeUpdateInputModel
    {
        [Required(ErrorMessage = "Укажите время начала работы")]
        [TimeFormat(ErrorMessage = "Укажите время в формате 'ЧЧ:ММ'")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "Укажите время окончания работы")]
        [TimeFormat(ErrorMessage = "Укажите время в формате 'ЧЧ:ММ'")]
        public DateTime End { get; set; }

        [Display(Name = "День недели")]
        [Range(1, 7)]
        public Weekday Weekday { get; set; }
    }
}
