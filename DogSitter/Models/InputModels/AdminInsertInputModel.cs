

namespace DogSitter.API.Models
{
    public class AdminInsertInputModel
    {
        //добавление

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ContactInsertInputModel> Contacts { get; set; }
    }
}
