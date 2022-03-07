using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attribute
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
                var result = new ValidationResult("Sorry, you are not old enough");
                return result;
            }
            
            return null;
        }
    }
}

