namespace DogSitter.BLL.Models
{
    public class PassportModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public string Division { get; set; }
        public string DivisionCode { get; set; }
        public string Registration { get; set; }
        public bool IsDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PassportModel model &&
                   Id == model.Id &&
                   FirstName == model.FirstName &&
                   LastName == model.LastName &&
                   DateOfBirth == model.DateOfBirth &&
                   Seria == model.Seria &&
                   Number == model.Number &&
                   IssueDate == model.IssueDate &&
                   Division == model.Division &&
                   DivisionCode == model.DivisionCode &&
                   Registration == model.Registration &&
                   IsDeleted == model.IsDeleted;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {DateOfBirth} {Seria} {Number} " +
                $"{IssueDate} {Division} {DivisionCode} {Registration} {IsDeleted}";
        }
    }
}
