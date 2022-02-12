namespace DogSitter.API.Models
{
    public class PassportOutputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public string Division { get; set; }
        public string DivisionCode { get; set; }
        public string Registration { get; set; }
    }
}
