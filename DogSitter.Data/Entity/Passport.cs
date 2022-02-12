using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Passport
    {
        public int Id { get; set; }
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
        public bool IsDeleted { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Passport passport &&
                   Id == passport.Id &&
                   FirstName == passport.FirstName &&
                   LastName == passport.LastName &&
                   DateOfBirth == passport.DateOfBirth &&
                   Seria == passport.Seria &&
                   Number == passport.Number &&
                   IssueDate == passport.IssueDate &&
                   Division == passport.Division &&
                   DivisionCode == passport.DivisionCode &&
                   Registration == passport.Registration &&
                   IsDeleted == passport.IsDeleted;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {DateOfBirth} {Seria} {Number} " +
                $"{IssueDate} {Division} {DivisionCode} {Registration} {IsDeleted}";
        }



    }
}
