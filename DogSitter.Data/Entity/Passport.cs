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

        public override string ToString()
        {
            return $"{FirstName} {LastName} {DateOfBirth} {Seria} {Number} " +
                $"{IssueDate} {Division} {DivisionCode} {Registration} {IsDeleted}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Passport)
            {
                return false;
            }
            if (Id != ((Passport)obj).Id
                || FirstName != ((Passport)obj).FirstName
                || LastName != ((Passport)obj).LastName
                || DateOfBirth != ((Passport)obj).DateOfBirth
                || Seria != ((Passport)obj).Seria
                || Number != ((Passport)obj).Number
                || IssueDate != ((Passport)obj).IssueDate
                || Division != ((Passport)obj).Division
                || DivisionCode != ((Passport)obj).DivisionCode
                || Registration != ((Passport)obj).Registration
                || IsDeleted != ((Passport)obj).IsDeleted)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
