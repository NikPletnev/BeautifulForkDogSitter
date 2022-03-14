using DogSitter.API.Attributes.CustomAttributes;
using DogSitter.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class WorkTimeInsertInputModel
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:dd/MM/yyyy hh:mm:ss tt")]
        [SitterDateTime]
        public DateTime Start { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:dd/MM/yyyy hh:mm:ss tt")]
        [EndTimeMoreThanStartTime(nameof(Start))]
        [SitterDateTime]
        public DateTime End { get; set; }

        [Display(Name = "День недели")]
        [Range(1, 7)]
        public Weekday Weekday { get; set; }
    }
}
