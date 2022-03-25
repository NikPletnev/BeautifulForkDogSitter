using DogSitter.API.Models;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attributes.CustomAttributes
{
    public class EndTimeMoreThanStartTime : CompareAttribute
    {
        public EndTimeMoreThanStartTime(string otherProperty) : base(otherProperty) { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueDateTime = validationContext.ObjectInstance as WorkTimeInsertInputModel;

            if (DateTime.Compare(valueDateTime.Start, valueDateTime.End) >= 0)
            {
                return new ValidationResult(ErrorMessage = "Incorrect WorkTime");
            }

            return null;
        }
    }
}
