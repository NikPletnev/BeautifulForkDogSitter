using DogSitter.API.Attributes.CustomAttributes;
using DogSitter.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class TimesheetInsertInputModel
    {
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:hh:mm:ss")]
        //[SitterDateTime]
        public DateTime Start { get; set; }

       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:hh:mm:ss")]
        //[EndTimeMoreThanStartTime(nameof(Start))]
       // [SitterDateTime]
        public DateTime End { get; set; }

        [Display(Name = "День недели")]
        [Range(1, 7)]
        public Weekday Weekday { get; set; }

    }
}
