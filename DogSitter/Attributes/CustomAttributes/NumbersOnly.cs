using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DogSitter.API.Attributes.CustomAttributes
{
    public class NumbersOnly : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new Regex(@"^([1-9]\d*)?\d$");

            string strValue = value as string;

            if (!regex.IsMatch(strValue))
            {
                return new ValidationResult("This field for figures only");
            }
            return null;
        }
    }
}
