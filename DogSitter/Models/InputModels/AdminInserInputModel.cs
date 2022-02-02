

namespace DogSitter.API.Models
{
    public class AdminInserInputModel : AdminUpdateOutputModel
    {
        //регистрация
        public string Password { get; set; }
        public List<ContactOutputModel> Contacts { get; set; }
    }
}
