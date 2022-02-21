using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class PassportUpdateInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Seria { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public string Division { get; set; }
        [Required]
        public string DivisionCode { get; set; }
        public string Registration { get; set; }
    }
}
