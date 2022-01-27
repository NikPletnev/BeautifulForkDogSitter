using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Entity
{
    public class Passport
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
        public string? Registration { get; set; }
        public Sitter Sitter { get; set; }
    }
}
