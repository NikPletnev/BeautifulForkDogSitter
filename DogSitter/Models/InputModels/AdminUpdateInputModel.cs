using DogSitter.API.Attributes.CustomAttributes;

namespace DogSitter.API.Models
{
    public class AdminUpdateInputModel //изменение
    {
        [TextOnly]
        public string FirstName { get; set; }
        [TextOnly]
        public string LastName { get; set; }

    }
}
