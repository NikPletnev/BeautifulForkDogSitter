using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AdminUpdateInputModel //изменение
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string LastName { get; set; }

    }
}
