namespace DogSitter.API.Models.InputModels
{
    public class SitterInsertInputModel //добавление
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<ContactUpdateInputModel> Contacts { get; set; }

    }
}
