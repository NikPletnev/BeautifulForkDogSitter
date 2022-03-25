using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attributes
{
    public class SitterMinAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;

            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < 16)
            {
                return new ValidationResult("Sorry, you are not old enough");
            }
            if (bday < new DateTime(1900, 01, 01))
            {
                return new ValidationResult("Incorrect date");
            }

            return null;
        }
    }
}

