using DogSitter.API.Attributes;
using DogSitter.API.Attributes.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class PassportUpdateInputModel
    {
        [Required]
        [TextOnly]
        public string FirstName { get; set; }

        [Required]
        [TextOnly]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [SitterMinAge]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{4})?$")]
        public string Seria { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{6})?$")]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CorrectPassportIssueDate]
        public DateTime IssueDate { get; set; }

        [Required]
        [TextOnly]
        public string Division { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3}[-]{1}[0-9]{3})?$")]
        public string DivisionCode { get; set; }
        public string Registration { get; set; }
    }
}
