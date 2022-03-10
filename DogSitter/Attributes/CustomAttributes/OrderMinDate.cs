using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attributes.CustomAttributes
{
    public class OrderMinDate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime orderDate = DateTime.Parse(value.ToString());

            if (orderDate > DateTime.Today | orderDate < DateTime.Today)
            {
                return new ValidationResult("Incorrect date");
            }

            return null;
        }
    }
}


