using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DogSitter.API.Attributes.CustomAttributes
{
    public class TextOnly : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new Regex(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$");

            string strValue = value as string;

            if (!regex.IsMatch(strValue))
            {
                return new ValidationResult("This field for text only");
            }
            return null;
        }
    }
}
