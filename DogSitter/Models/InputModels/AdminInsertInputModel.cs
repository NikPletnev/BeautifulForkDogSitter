

namespace DogSitter.API.Models
{
    public class AdminInsertInputModel : AdminUpdateOutputModel
    {
        //добавление
        public string Password { get; set; }
        public List<ContactUpdateOutputModel> Contacts { get; set; }
    }
}
