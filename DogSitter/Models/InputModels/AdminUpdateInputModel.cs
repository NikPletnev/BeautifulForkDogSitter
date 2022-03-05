using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class AdminUpdateInputModel //изменение
    {
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^([а-яёА-ЯЁ\s]+|[a-zA-Z\s]+)$")]
        public string LastName { get; set; }

    }
}
