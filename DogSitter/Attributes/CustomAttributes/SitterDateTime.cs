using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attributes.CustomAttributes
{
    public class SitterDateTime : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime workTime = DateTime.Parse(value.ToString());

            if (workTime < DateTime.Today)
            {
                return new ValidationResult("Incorrect WorkTime");
            }

            return null;
        }
    }
}
