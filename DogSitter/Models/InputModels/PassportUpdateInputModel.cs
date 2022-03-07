using DogSitter.API.Attribute;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class PassportUpdateInputModel
    {
        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [SitterMinAge]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^([1-9]\d*)?\d$")]
        public string Seria { get; set; }

        [Required]
        [RegularExpression(@"^([1-9]\d*)?\d$")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required]
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string Division { get; set; }

        [Required]
        [RegularExpression(@"^([1-9]\d*)?\d$")]

        public string DivisionCode { get; set; }
        public string Registration { get; set; }
    }
}
