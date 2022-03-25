using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Attributes
{
    public class CorrectPassportIssueDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime issueDate = DateTime.Parse(value.ToString());

            if (issueDate >= DateTime.Today | issueDate < new DateTime(1993, 06, 12))
            {
                return new ValidationResult("Incorrect issue date");
            }

            return null;
        }
    }
}
